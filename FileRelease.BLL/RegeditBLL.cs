// ****************************************
// FileName:RegeditBLL.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/30 21:20:43
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace FileRelease.BLL
{
    using Microsoft.Win32;
    using Util;

    /// <summary>
    /// 注册表读取
    /// </summary>
    public class RegeditBLL
    {
        const String SPLITOR = "\\";
        const String VS_RECENT_FOLDER = "ProjectMRUList";
        const String VS_RECENT_PROJECT_PATH = @"Software\Microsoft\VisualStudio";

        /// <summary>
        /// 获取最近打开的项目列表
        /// </summary>
        /// <param name="release">默认发布文件;为false时,打包项目源代码</param>
        /// <returns></returns>
        public static List<String> GetRecentProjects(Boolean release = true)
        {
            List<String> projectRecords = new List<String>();
            List<String> projects = new List<String>();

            foreach (var subKey in GetSubKeyNames(Registry.CurrentUser, VS_RECENT_PROJECT_PATH).Where(p => p.EndsWith(".0")))
            {
                String subKeyPath = VS_RECENT_PROJECT_PATH + SPLITOR + subKey;

                if (Exist(Registry.CurrentUser, subKeyPath, VS_RECENT_FOLDER))
                {
                    projectRecords.AddRange(GetValueNames(Registry.CurrentUser, subKeyPath + SPLITOR + VS_RECENT_FOLDER));
                }
            }

            //移除多余名称
            foreach (var item in projectRecords)
            {
                projects.Add(item.Split('|')[0]);
            }

            //筛选
            var suitList = projects.Where(p => p.EndsWith(".sln") || p.EndsWith(".csproj"))
                                   .Where(p => !p.StartsWith("%"))
                                   .Where(p => p.ExistsEx());

            List<String> releaseList = new List<String>();

            if (!release)
            {
                foreach (var item in suitList)
                {
                    releaseList.Add(Directory.GetParent(item).FullName);
                }

                return releaseList;
            }

            foreach (var item in suitList)
            {
                foreach (var folder in Directory.GetParent(item).GetDirectories())
                {
                    if (CanRelease(folder.FullName))
                    {
                        releaseList.Add(GetDebugFolder(folder.FullName));
                    }

                    foreach (var subFolder in Directory.GetDirectories(folder.FullName))
                    {
                        if (CanRelease(subFolder))
                        {
                            releaseList.Add(GetDebugFolder(subFolder));
                        }
                    }
                }
            }

            return releaseList;
        }

        /// <summary>
        /// 是否能发布
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        private static Boolean CanRelease(String folder)
        {
            foreach (var item in Directory.GetFiles(folder))
            {
                var fileName = Path.GetFileName(item);

                if (String.Equals(fileName, "app.config", StringComparison.OrdinalIgnoreCase)
                    || String.Equals(fileName, "web.config", StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// GetDebugFolder
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        private static String GetDebugFolder(String folder)
        {
            return String.Format("{0}\\bin\\Debug", folder);
        }

        /// <summary>
        /// 获取注册表子节点名称列表
        /// </summary>
        /// <returns></returns>
        public static String[] GetSubKeyNames(RegistryKey root, String path)
        {
            RegistryKey key = root.OpenSubKey(path);

            return key.GetSubKeyNames();
        }

        /// <summary>
        /// 获取注册表子节点名称列表
        /// </summary>
        /// <returns></returns>
        public static String[] GetSubValueNames(RegistryKey root, String path)
        {
            RegistryKey key = root.OpenSubKey(path);

            return key.GetValueNames();
        }

        /// <summary>
        /// 获取注册表子节点名称列表
        /// </summary>
        /// <returns></returns>
        public static List<String> GetValueNames(RegistryKey root, String path)
        {
            RegistryKey key = root.OpenSubKey(path);

            var valueList = new List<String>();
            foreach (var item in GetSubValueNames(root, path))
            {
                valueList.Add(key.GetValue(item).ToString());
            }

            return valueList;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="root"></param>
        /// <param name="path"></param>
        /// <param name="subName"></param>
        /// <returns></returns>
        public static Boolean Exist(RegistryKey root, String path, String subName)
        {
            RegistryKey ket = root.OpenSubKey(path);

            return ket.GetSubKeyNames().Contains(subName);
        }
    }
}