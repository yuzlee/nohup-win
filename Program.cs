using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Console
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string path = Application.StartupPath + "\\";
            string dllFileName = "Newtonsoft.Json.dll";
            //******加载Newtonsoft.Json.dll******
            if (!File.Exists(path + dllFileName))   //文件不存在
            {
                FileStream fs = new FileStream(path + dllFileName, FileMode.CreateNew, FileAccess.Write);
                byte[] buffer = Properties.Resources.Newtonsoft_Json;//{GetData是命名空间}
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }
            //*****************************


            Application.Run(new mainForm(args));
        }
    }
}
