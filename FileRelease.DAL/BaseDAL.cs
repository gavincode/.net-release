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

namespace FileRelease.DAL
{
    using FileRelease.Model;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Conventions.Helpers;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;
    using Util.Config;

    /// <summary>
    /// 数据访问基类
    /// </summary>
    public class BaseDAL
    {
        //数据库文件
        private static readonly String DbFile = "db.db";

        //全局静态ISessionFactory
        public static readonly ISessionFactory Instance = null;

        #region 初始化

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static BaseDAL()
        {
            Instance = Fluently.Configure()
           .Database(MySQLConfiguration.Standard.ConnectionString("DataSource=192.168.1.240;port=3306;UserId=root;Password=1234;Database=gavin_develop;Allow Zero Datetime=true;AllowUserVariables=True;charset=utf8;pooling=true;MinimumPoolSize=20;maximumpoolsize=200;command timeout=60;"))
           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Project>().Conventions.Add(DefaultCascade.All()))
           .ExposeConfiguration(CreateSchema)
           .BuildSessionFactory();
        }

        /// <summary>
        /// 创建表接口
        /// </summary>
        /// <param name="cfg">Configuration</param>
        protected static void CreateSchema(Configuration cfg)
        {
            if (ConfigUtil.GetAppSetting("CreateSchema") == "true")
                new SchemaExport(cfg).Create(false, true);
        }

        #endregion

        #region 继承类访问方法

        /// <summary>
        /// 开启一个ISession
        /// </summary>
        /// <returns></returns>
        protected static ISession OpenSession()
        {
            return Instance.OpenSession(new MonitorInterceptor());
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="action">需要执行的方法</param>
        /// <returns></returns>
        protected static void Excute(Action<ISession> action)
        {
            try
            {
                using (var session = OpenSession())
                {
                    action(session);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="action">需要执行的方法</param>
        /// <returns></returns>
        protected static Int32 Excute(Func<ISession, Int32> action)
        {
            try
            {
                using (var session = OpenSession())
                {
                    return action(session);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="action">需要执行的方法</param>
        /// <returns></returns>
        protected static TResult Excute<TResult>(Func<ISession, TResult> action)
        {
            try
            {
                using (var session = OpenSession())
                {
                    return action(session);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="action">需要执行的方法</param>
        /// <returns></returns>
        protected static IList<TResult> Excute<TResult>(Func<ISession, IList<TResult>> action)
        {
            try
            {
                using (var session = OpenSession())
                {
                    return action(session);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region 单表基本操作

        /// <summary>
        /// 获取所有Project列表
        /// </summary>
        /// <returns></returns>
        public static IList<TResult> All<TResult>() where TResult : class
        {
            return Excute<TResult>(p => p.QueryOver<TResult>().List());
        }

        /// <summary>
        /// 获取单个Project
        /// </summary>
        /// <param name="id">键值</param>
        /// <returns></returns>
        public static TResult Get<TResult>(Object id) where TResult : class
        {
            return Excute<TResult>(p => p.Get<TResult>(id));
        }

        /// <summary>
        /// 保存单个记录
        /// </summary>
        /// <typeparam name="TInput">修改类型</typeparam>
        /// <param name="input">修改类型实例</param>
        public static void Save<TInput>(TInput input)
        {
            Excute(p => { p.Save(input); p.Flush(); });
        }

        /// <summary>
        /// 保存或更新单个记录
        /// </summary>
        /// <typeparam name="TInput">修改类型</typeparam>
        /// <param name="input">修改类型实例</param>
        public static void SaveOrUpdate<TInput>(TInput input)
        {
            Excute(p => { p.SaveOrUpdate(input); p.Flush(); });
        }

        /// <summary>
        /// 更新单个记录
        /// </summary>
        /// <typeparam name="TInput">修改类型</typeparam>
        /// <param name="input">修改类型实例</param>
        public static void Update<TInput>(TInput input)
        {
            Excute(p => { p.Update(input); p.Flush(); });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="input"></param>
        public static void Delete<TInput>(TInput input)
        {
            Excute(p => { p.Delete(input); p.Flush(); });
        }

        #endregion
    }
}