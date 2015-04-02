using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileRelease.Model
{
    public class Project
    {
        public virtual Int32 Id { get; set; }

        public virtual String Name { get; set; }

        public virtual String UIFolder { get; set; }

        public virtual String ReleaseFolder { get; set; }

        public virtual DateTime LastTime { get; set; }

        public virtual Filter Filter { get; set; }

        /// <summary>
        /// 添加过滤器
        /// </summary>
        /// <param name="filter"></param>
        public virtual void AddFilter(Filter filter)
        {
            this.Filter = filter;
            filter.Project = this;
        }
    }
}
