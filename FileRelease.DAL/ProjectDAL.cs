// ****************************************
// FileName:ProjectDAL.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/30 11:08:15
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Dapper;

namespace FileRelease.DAL
{
    using FileRelease.Model;

    /// <summary>
    /// Project数据访问
    /// </summary>
    public class ProjectDAL
    {
        public static void Update(Project project)
        {
            BaseDAL.NewConnection().Execute(AutoSQL<Project>.Update("Id"), project);
        }

        public static Project QueryOne(Guid id)
        {
            return BaseDAL.NewConnection().Query<Project>(AutoSQL<Project>.Query("Id"), new { Id = id }).FirstOrDefault();
        }

        public static void Delete(Project project)
        {
            BaseDAL.NewConnection().Execute(AutoSQL<Project>.Delete("Id"), project);
        }

        public static IEnumerable<Project> Query()
        {
            return BaseDAL.NewConnection().Query<Project>(AutoSQL<Project>.Query(), null);
        }

        public static void Insert(Project project)
        {
            BaseDAL.NewConnection().Execute(AutoSQL<Project>.Insert, project);
        }
    }
}
