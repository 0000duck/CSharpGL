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
            var array = new UnmanagedArray<int>(10);
            unsafe
            {
                Func<int, int, int> comparer = (x, y) => x - y;
                array.Header.Sort(0, 10, comparer);
                var p = (int*)array.Header.ToPointer();
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(p[i]);
                }
            }
            string filename = string.Format("CSharpGL{0:yyyy-MM-dd_HH-mm-ss.ff}.log", DateTime.Now);
            Debug.Listeners.Add(new TextWriterTraceListener(filename));
            Debug.AutoFlush = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
            Debug.Close();
            Debug.Listeners.Clear();
        }
    }
}