// ****************************************
// FileName:ZipCreator.cs
// Description:
// Tables:
// Author:Gavin
// Create Date:2015/3/31 22:58:18
// Revision History:
// ****************************************

using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace FileRelease.Utils
{
    using Ionic.Zip;

    public class ZipCreator
    {
        /// <summary>
        /// 打包压缩文件夹
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="CompressedFoder"></param>
        public static void CompressFoder(String folder, String CompressedFoder)
        {
            using (ZipFile zip = new ZipFile(Encoding.Default))
            {
                //添加文件夹
                zip.AddDirectory(folder);

                //保存
                zip.Save(CompressedFoder);
            }
        }
    }
}