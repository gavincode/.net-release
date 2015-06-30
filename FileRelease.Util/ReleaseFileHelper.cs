using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;
using FileRelease.Model;

namespace FileRelease.Utils
{
    public class ReleaseFileHelper
    {
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="projectName">项目别名</param>
        /// <param name="uiFolder">项目UI路径</param>
        /// <param name="releaseFolders">发布包存放夹路径的数组符串(以逗号分割)</param>
        /// <param name="lastReleaseTime">上一次发布时间 (增量发布有效)</param>
        /// <param name="createFolder">是否创建发布包文件夹</param>
        public static void Release(string projectName, string uiFolder, string releaseFolders, DateTime lastReleaseTime, Boolean createFolder, Project project, ref String releasedFolder)
        {
            if (project.GetFilter() != null)
            {
                FileForeachHelper.fileFilter = project.GetFilter().FileList();
                FileForeachHelper.folderFilter = project.GetFilter().FolderList();
                FileForeachHelper.fileTypeFilter = project.GetFilter().TypeList();
                FileForeachHelper.fileKeyWordFilter = project.GetFilter().KeyWordList();
            }

            //获取项目UI路径下过滤后的所有文件
            List<String> fileList = FileForeachHelper.GetAllFiles(uiFolder);

            String[] releaseFoldersArray = releaseFolders.Split(',');

            for (int i = 0; i < releaseFoldersArray.Length; i++)
            {
                //新发布包文件夹
                String newReleaseFolder = createFolder ? GetReleaseFolder(projectName, releaseFoldersArray[i]) : releaseFoldersArray[i];

                releasedFolder = newReleaseFolder;

                if (lastReleaseTime != DateTime.MinValue)
                {
                    CopyReleaseFiles(fileList, uiFolder, newReleaseFolder, lastReleaseTime);
                }
                else
                {
                    CopyReleaseFiles(fileList, uiFolder, newReleaseFolder);
                }
            }
        }

        /// <summary>
        /// 获取发布包下新发布文件夹
        /// </summary>
        /// <param name="projectName">项目名称</param>
        /// <param name="releaseFolder">发布包路径</param>
        /// <returns>发布包下新增的发布文件夹</returns>
        private static String GetReleaseFolder(String projectName, String releaseFolder)
        {
            //发布包下的文件夹列表
            List<String> folderList = Directory.GetFiles(releaseFolder).ToList();
            folderList.AddRange(Directory.GetDirectories(releaseFolder));

            //获取当前项目发布包集合
            var query = folderList
                .Where(r => Path.GetFileName(r).StartsWith(projectName))
                .OrderByDescending(q =>
                {
                    var info = new DirectoryInfo(q);
                    return info.CreationTime;
                });

            //最新项目发布包
            String lastReleaseFolder = query.Count() == 0 ? null : query.First();

            String newFolder = String.Empty;
            String currentDate = DateTime.Today.ToString("yyyy-MM-dd");

            if (lastReleaseFolder != null)
            {
                //获取文件夹创建时间
                var info = new DirectoryInfo(lastReleaseFolder);

                if (info.CreationTime.Date == DateTime.Now.Date)
                {
                    if (lastReleaseFolder.EndsWith(".rar"))
                        lastReleaseFolder = lastReleaseFolder.Remove(lastReleaseFolder.Length - 4);

                    Int32 index = 0;
                    if (Int32.TryParse(lastReleaseFolder.Substring(lastReleaseFolder.Length - 3), out index))
                    {
                        String nextIndexString = (index + 1).ToString().PadLeft(3, '0');
                        newFolder = string.Format("{0}-{1}-{2}", projectName, currentDate, nextIndexString);
                    }
                }
                else
                {
                    newFolder = string.Format("{0}-{1}-{2}", projectName, currentDate, "001");
                }
            }
            else
            {
                newFolder = string.Format("{0}-{1}-{2}", projectName, currentDate, "001");
            }

            return Path.Combine(releaseFolder, newFolder);
        }

        /// <summary>
        /// 拷贝发布文件到发布包
        /// </summary>
        /// <param name="fileList">发布项目文件列表</param>
        /// <param name="uiFolder">发布项目主目录</param>
        /// <param name="releaseFolder">发布路径</param>
        /// <param name="lastReleaseTime">上一次发布时间</param>
        private static void CopyReleaseFiles(List<String> fileList, string uiFolder, string releaseFolder, DateTime lastReleaseTime)
        {
            //创建发布包文件夹
            Directory.CreateDirectory(releaseFolder);

            fileList.ForEach(p =>
            {
                //获取文件信息
                FileInfo info = new FileInfo(p);

                //仅当文件上一次修改时间大于上一次发布时间,才发布
                if (info.LastWriteTime > lastReleaseTime)
                {
                    String filePath = p.Replace(uiFolder, releaseFolder);

                    if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    }

                    File.Copy(p, filePath, true);
                }
            });
        }

        /// <summary>
        /// 拷贝发布文件到发布包
        /// </summary>
        /// <param name="fileList">发布项目文件列表</param>
        /// <param name="uiFolder">发布项目主目录</param>
        /// <param name="releaseFolder">发布路径</param>
        private static void CopyReleaseFiles(List<String> fileList, string uiFolder, string releaseFolder)
        {
            //创建发布包文件夹
            Directory.CreateDirectory(releaseFolder);

            fileList.ForEach(p =>
            {
                //发布后的文件路径
                String filePath = p.Replace(uiFolder, releaseFolder);

                //判断文件路径是否存在
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                }

                //拷贝文件
                File.Copy(p, filePath, true);
            });
        }

        /// <summary>
        /// 移动dll
        /// </summary>
        /// <param name="baseFolder"></param>
        /// <param name="targetFolder"></param>
        public static void MoveDLLs(String baseFolder, String targetFolder)
        {
            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);

            foreach (var item in Directory.GetFiles(baseFolder))
            {
                if (item.EndsWith(".dll"))
                    File.Move(item, Path.Combine(targetFolder, Path.GetFileName(item)));
            }
        }
    }
}