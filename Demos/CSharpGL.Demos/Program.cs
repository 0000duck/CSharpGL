﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            string filename = string.Format("CSharpGL{0:yyyy-MM-dd_HH-mm-ss.ff}.log", DateTime.Now);
            Debug.Listeners.Add(new TextWriterTraceListener(filename));
            Debug.AutoFlush = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CSharpGL.Demos._00GLCanvas.Form1());
            {
                ErrorCode error = (ErrorCode)OpenGL.GetError();
                if (error != ErrorCode.NoError)
                {
                    Debug.WriteLine(string.Format("OpenGL error: {0}", error));
                }
            }
            Debug.Close();
            Debug.Listeners.Clear();
        }
    }
}