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
using FluentNHibernate.Mapping;

namespace FileRelease.Model.Map
{
    using Util;

    /// <summary>
    /// 过滤器
    /// </summary>
    public class FilterMap : ClassMap<Filter>
    {
        public FilterMap()
        {
            Id(x => x.Id).GeneratedBy.Foreign("Project");
            Map(x => x.Files);
            Map(x => x.Folders);
            Map(x => x.Types);
            Map(x => x.KeyWords);
            HasOne<Project>(x => x.Project).Cascade.Delete().Constrained();
        }
    }
}