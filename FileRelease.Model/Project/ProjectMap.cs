// ****************************************
// FileName:RrojectMap.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/28 15:57:28
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace FileRelease.Model.Map
{
    public class RrojectMap : ClassMap<Project>
    {
        public RrojectMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.UIFolder);
            Map(x => x.ReleaseFolder);
            Map(x => x.LastTime);
            HasOne<Filter>(x => x.Filter).Cascade.Delete();
        }
    }
}
