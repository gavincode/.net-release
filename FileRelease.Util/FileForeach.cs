﻿// ****************************************
// FileName:FileForeach
// Description:文件遍历帮助类
// Tables:None
// Author:Gavin
// Create Date:2014/8/13 17:06:33
// Revision History:
// ****************************************

using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace FileRelease.Utils
{
    /// <summary>
    /// 文件遍历帮助类
    /// </summary>
    public static class FileForeachHelper
    {
        #region 私有属性

        /// <summary>
        /// 文件过滤
        /// </summary>
        public static List<String> fileFilter { get; set; }

        /// <summary>
        /// 文件类型过滤
        /// </summary>
        public static List<String> fileTypeFilter { get; set; }

        /// <summary>
        /// 文件夹过滤
        /// </summary>
        public static List<String> folderFilter { get; set; }

        /// <summary>
        /// 文件名关键字过滤
        /// </summary>
        public static List<String> fileKeyWordFilter { get; set; }

        //过滤文件夹名
        private static String fnFilterFolder { get; set; }

        //过滤文本文档名称
        private static String fnFileTypeText
        {
            get { return fnFilterFolder + "文件类型过滤.txt"; }
        }

        private static String fnFileText
        {
            get { return fnFilterFolder + "文件过滤.txt"; }
        }

        private static String fnFileKeyWordText
        {
            get { return fnFilterFolder + "文件关键字过滤.txt"; }
        }

        private static String fnFolderText
        {
            get { return fnFilterFolder + "文件夹过滤.txt"; }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 初始化文件过滤数据
        /// </summary>
        public static void Init()
        {
            fileKeyWordFilter = new List<String>();
            folderFilter = new List<String>();
            fileTypeFilter = new List<String>();
            fileFilter = new List<String>();

            ////文件过滤文件夹
            //fnFilterFolder = String.Format("{0}\\{1}\\", Environment.CurrentDirectory, "FileFilter");

            ////如果文件过滤文档不存在,则创建
            //if (!Directory.Exists(fnFilterFolder)) Directory.CreateDirectory(fnFilterFolder);
            //if (!File.Exists(fnFileKeyWordText)) File.Create(fnFileKeyWordText).Close();
            //if (!File.Exists(fnFileText)) File.Create(fnFileText).Close();
            //if (!File.Exists(fnFileTypeText)) File.Create(fnFileTypeText).Close();
            //if (!File.Exists(fnFolderText)) File.Create(fnFolderText).Close();

            ////读取过滤数据
            //fileFilter = File.ReadAllLines(fnFileText).ToList();
            //fileKeyWordFilter = File.ReadAllLines(fnFileKeyWordText).ToList();
            //fileTypeFilter = File.ReadAllLines(fnFileTypeText).ToList();
            //folderFilter = File.ReadAllLines(fnFolderText).ToList();
        }

        /// <summary>
        /// 遍历获取路径下的所有文件
        /// </summary>
        /// <param name="currentPath"></param>
        /// <returns></returns>
        public static List<String> GetAllFiles(String currentPath)
        {
            List<String> fileList = new List<String>();

            GetAllFiles(currentPath, ref fileList);

            return fileList;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 遍历获取路径下的所有文件
        /// </summary>
        /// <param name="currentPath">当前路径</param>
        /// <param name="fileList">存放文件的集合</param>
        /// <returns>文件集合</returns>
        private static void GetAllFiles(String currentPath, ref List<String> fileList)
        {
            //获取当前路径的文件夹名称
            String fileName = Path.GetFileName(currentPath);

            //排除指定文件夹
            if (folderFilter.Contains(fileName)) return;

            //获取当前目录下的所有文件
            var allFileQuery = Directory.GetFiles(currentPath)
                                        .Where(p => !fileTypeFilter.Contains(Path.GetExtension(p))
                                                 && !fileFilter.Contains(Path.GetFileName(p))
                                                 && !fileKeyWordFilter.Any(q => Path.GetFileName(p).Contains(q)));

            //添加到列表
            fileList.AddRange(allFileQuery);

            foreach (string dir in Directory.GetDirectories(currentPath))
            {
                GetAllFiles(dir, ref fileList);
            }
        }

        /// <summary>
        /// 静态初始化
        /// </summary>
        static FileForeachHelper()
        {
            Init();
        }

        #endregion
    }

    /// <summary>
    /// 文件过滤类型枚举
    /// </summary>
    public enum FileFilterTypeEnum
    {
        /// <summary>
        /// 文件夹
        /// </summary>
        FolderFilter,

        /// <summary>
        /// 文件类型
        /// </summary>
        FileTypeFilter,

        /// <summary>
        /// 文件
        /// </summary>
        FileFilter,

        /// <summary>
        /// 文件关键字
        /// </summary>
        FileKeyWordFilter
    }
}