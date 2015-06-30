// ****************************************
// FileName:FilterDAL.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/31 17:25:23
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using FileRelease.Model;
using System.Data.SQLite;
using Dapper;

namespace FileRelease.DAL
{
    public class FilterDAL
    {
        public static Filter QueryOne(Object id)
        {
            return BaseDAL.NewConnection().Query<Filter>(AutoSQL<Filter>.Query("Id"), id).FirstOrDefault();
        }

        public static void Delete(Object id)
        {
            BaseDAL.NewConnection().Execute(AutoSQL<Filter>.Delete("Id"), new { Id = id });
        }

        public static void SaveOrUpdate(Filter filter)
        {
            var query = BaseDAL.NewConnection().Query<Filter>(AutoSQL<Filter>.Query("Id"), new { Id = filter.Id });

            //有则更新, 无则新增
            if (query.Count() > 0)
                BaseDAL.NewConnection().Execute(AutoSQL<Filter>.Update("Id"), filter);
            else
                BaseDAL.NewConnection().Execute(AutoSQL<Filter>.Insert, filter);
        }
    }
}
