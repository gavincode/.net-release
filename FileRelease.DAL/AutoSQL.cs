//***********************************************************************************
// 文件名称：AutoSQL.cs
// 功能描述：
// 数据表：
// 作者：Gavin
// 日期：2015/6/29 11:16:20
// 修改记录：
//***********************************************************************************

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace FileRelease.DAL
{
    /// <summary>
    /// 实体数据库操作基本sql生成类 (sqlite)
    /// </summary>
    internal class AutoSQL<T> where T : class
    {
        //缓存的sql语句
        private static Dictionary<String, String> CachedSqls = new Dictionary<String, String>();

        public static String Create
        {
            get
            {
                Type type = typeof(T);

                String key = type.Name + "_Create";
                if (CachedSqls.ContainsKey(key)) return CachedSqls[key];

                String propInfo = String.Empty;
                foreach (var item in type.GetProperties())
                {
                    String name = item.Name;
                    var typeName = ToSqliteType(item.PropertyType);

                    if (name.ToUpper() == "ID" && typeName == "INTEGER") typeName += " PRIMARY KEY AUTOINCREMENT";

                    propInfo += String.Format("{0} {1},", name, typeName);
                }

                var resultSQL = String.Format("CREATE TABLE IF NOT EXISTS '{0}' ( {1} );", type.Name, propInfo.TrimEnd(','));

                CachedSqls[key] = resultSQL;

                return resultSQL;
            }
        }

        public static String Insert
        {
            get
            {
                Type type = typeof(T);

                String key = type.Name + "_Insert";
                if (CachedSqls.ContainsKey(key)) return CachedSqls[key];

                String propInfo = String.Empty;
                String valueInfo = String.Empty;
                foreach (var item in type.GetProperties())
                {
                    propInfo += String.Format("{0},", item.Name);
                    valueInfo += String.Format("@{0},", item.Name);
                }

                var resultSQL = String.Format("INSERT INTO '{0}' ({1}) VALUES ({2});", type.Name, propInfo.TrimEnd(','), valueInfo.TrimEnd(','));

                CachedSqls[key] = resultSQL;

                return resultSQL;
            }
        }

        public static String Update(params String[] whereArgNames)
        {
            Type type = typeof(T);

            String key = type.Name + "_Update";

            if (whereArgNames != null && whereArgNames.Length > 0)
            {
                key += "_";
                key += String.Join("_", whereArgNames);
            }

            if (CachedSqls.ContainsKey(key)) return CachedSqls[key];

            String propInfo = String.Empty;
            foreach (var item in type.GetProperties())
            {
                propInfo += String.Format("{0} = @{0},", item.Name);
            }

            String whereSQL = String.Empty;
            if (whereArgNames != null && whereArgNames.Length > 0)
            {
                whereSQL = "WHERE ";
                for (int i = 0; i < whereArgNames.Length; i++)
                {
                    if (i != 0) whereSQL += ",AND ";
                    whereSQL += String.Format("{0} = @{0}", whereArgNames[i]);
                }
            }

            var resultSQL = String.Format("UPDATE '{0}' SET {1} {2};", type.Name, propInfo.TrimEnd(','), whereSQL);

            CachedSqls[key] = resultSQL;

            return resultSQL;
        }

        public static String Delete(params String[] whereArgNames)
        {
            Type type = typeof(T);

            String key = type.Name + "_Delete";

            if (whereArgNames != null && whereArgNames.Length > 0)
            {
                key += "_";
                key += String.Join("_", whereArgNames);
            }

            if (CachedSqls.ContainsKey(key)) return CachedSqls[key];

            String whereSQL = String.Empty;
            if (whereArgNames != null && whereArgNames.Length > 0)
            {
                whereSQL = "WHERE ";
                for (int i = 0; i < whereArgNames.Length; i++)
                {
                    if (i != 0) whereSQL += ",AND ";
                    whereSQL += String.Format("{0} = @{0}", whereArgNames[i]);
                }
            }

            var resultSQL = String.Format("DELETE FROM '{0}' {1};", type.Name, whereSQL);

            CachedSqls[key] = resultSQL;

            return resultSQL;
        }

        public static String Query(params String[] whereArgNames)
        {
            Type type = typeof(T);

            String key = type.Name + "_Query";

            if (whereArgNames != null && whereArgNames.Length > 0)
            {
                key += "_";
                key += String.Join("_", whereArgNames);
            }

            if (CachedSqls.ContainsKey(key)) return CachedSqls[key];

            String whereSQL = String.Empty;
            if (whereArgNames != null && whereArgNames.Length > 0)
            {
                whereSQL = "WHERE ";
                for (int i = 0; i < whereArgNames.Length; i++)
                {
                    if (i != 0) whereSQL += ",AND ";
                    whereSQL += String.Format("{0} = @{0}", whereArgNames[i]);
                }
            }

            var resultSQL = String.Format("SELECT * FROM '{0}' {1};", type.Name, whereSQL);

            CachedSqls[key] = resultSQL;

            return resultSQL;
        }

        private static String ToSqliteType(Type type)
        {
            var typeCode = Type.GetTypeCode(type);

            String resultType = String.Empty;

            switch (typeCode)
            {
                case TypeCode.Boolean:
                    resultType = "Boolean";
                    break;
                case TypeCode.DateTime:
                    resultType = "DateTime";
                    break;
                case TypeCode.Decimal:
                    resultType = "Decimal";
                    break;
                case TypeCode.Double:
                    resultType = "Double";
                    break;
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    resultType = "INTEGER";
                    break;
                case TypeCode.String:
                    resultType = "TEXT";
                    break;
                default:
                    resultType = "TEXT";
                    break;
            }

            return resultType;
        }
    }
}