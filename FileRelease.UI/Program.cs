using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileRelease.BLL;
using Util.Log;

namespace FileRelease.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //初始化Log路径
            LogUtil.SetLogPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG

            Application.Run(new Main());

#endif

#if !DEBUG

            try
            {
                Application.Run(new Main());
            }
            catch (Exception ex)
            {
                LogUtil.Write(ex.Message + Environment.NewLine + ex.StackTrace, LogType.Error);
                MessageBox.Show("请查看错误日志!");
            }

#endif

        }
    }
}
