// ****************************************
// FileName:CommonBLL.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/30 21:11:40
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.IO;
using Util;

namespace FileRelease.BLL
{
    /// <summary>
    /// 一般逻辑处理
    /// </summary>
    public class CommonBLL
    {
        public static Guid EditId = Guid.Empty;

        /// <summary>
        /// 获取运行时程序集环境
        /// </summary>
        /// <returns></returns>
        public static String GetPrivatePath(String releasedFolder)
        {
            var privatePath = String.Empty;

            if (releasedFolder.IsNullOrEmpty())
            {
                return privatePath;
            }

            var configFile = Directory.GetFiles(releasedFolder).FirstOrDefault(p => p.EndsWith(".config"));
            if (configFile == null)
            {
                return privatePath;
            }

            var privatePathLine = File.ReadAllLines(configFile).ToList().FirstOrDefault(p => p.Contains("privatePath"));

            if (privatePathLine != null)
            {
                privatePath = privatePathLine.Split('"')[1];
            }

            return privatePath;
        }

        /// <summary>
        /// 获取默认Release文件夹
        /// </summary>
        /// <param name="uiFolder"></param>
        /// <returns></returns>
        public static List<String> GetReleaseFolders(String uiFolder)
        {
            return Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)).ToList();
        }
    }
}