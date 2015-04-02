// ****************************************
// FileName:Monitor.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/30 17:07:08
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace FileRelease.Model
{
    using NHibernate;
    using NHibernate.SqlCommand;
    using Util.Log;

    public class MonitorInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            //将sql写入日志
            LogUtil.Write(sql.ToString(), LogType.Debug);
            return base.OnPrepareStatement(sql);
        }
    }
}
