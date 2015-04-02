// ****************************************
// FileName:Filter.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/31 16:22:37
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace FileRelease.Model
{
    using Util;

    /// <summary>
    /// 过滤器
    /// </summary>
    public class Filter
    {
        public virtual Int32 Id { get; set; }

        public virtual String Folders { get; set; }

        public virtual String Files { get; set; }

        public virtual String Types { get; set; }

        public virtual String KeyWords { get; set; }

        public virtual Project Project { get; set; }

        public virtual List<String> FolderList
        {
            get
            {
                return BuildList(Folders);
            }
        }

        public virtual List<String> FileList
        {
            get
            {
                return BuildList(Files);
            }
        }
        public virtual List<String> TypeList
        {
            get
            {
                return BuildList(Types);
            }
        }
        public virtual List<String> KeyWordList
        {
            get
            {
                return BuildList(KeyWords);
            }
        }

        /// <summary>
        /// 构造列表
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
        private List<String> BuildList(String strArray)
        {
            List<String> folderList = new List<String>();
            if (strArray.IsNullOrEmpty()) return folderList;

            folderList.AddRange(strArray.Split(','));

            return folderList;
        }
    }
}