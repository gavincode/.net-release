using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileRelease.Model
{
    public class Project
    {
        public virtual Guid Id { get; set; }

        public virtual String Name { get; set; }

        public virtual String UIFolder { get; set; }

        public virtual String ReleaseFolder { get; set; }

        public virtual DateTime LastTime { get; set; }

        private Filter Filter { get; set; }

        /// <summary>
        /// 获取过滤器
        /// </summary>
        /// <returns></returns>
        public Filter GetFilter()
        {
            return Filter;
        }

        /// <summary>
        /// 添加过滤器
        /// </summary>
        /// <param name="filter"></param>
        public virtual void SetFilter(Filter filter)
        {
            this.Filter = filter;
        }
    }
}
