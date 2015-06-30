// ****************************************
// FileName:BaseDAL.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/30 11:20:46
// Revision History:
// ****************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SQLite;

namespace FileRelease.DAL
{
    using FileRelease.Model;
    using Util.Config;

    /// <summary>
    /// 数据访问基类
    /// </summary>
    public class BaseDAL
    {
        //数据库文件
        private static readonly String DbFile = "db.db";

        public static SQLiteConnection NewConnection()
        {
            return new SQLiteConnection("Data Source=" + DbFile);
        }
    }
}