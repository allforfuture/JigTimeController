using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace JigTimeController
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Process process = RunningInstance();
                if (process == null)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Main());
                }
                else
                {
                    //MessageBox.Show("相同路径的该程序已启动", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Environment.Exit(0);
                    HandleRunningInstance(process);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 是否运行两次以上（同一路径）
        /// </summary>
        /// <returns></returns>
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //Loop through the running processes in with the same name
            foreach (Process process in processes)
            {
                //Ignore the current process
                if (process.Id != current.Id)
                {
                    //Make sure that the process is running from the exe file.
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //if the run path Different then return the other process instance.
                        if (process.MainModule.FileName == current.MainModule.FileName)
                            return process;
                    }
                }
            }
            //No other instance was found, return null.
            return null;
        }

        public static void HandleRunningInstance(Process process)
        {
            //显示
            //const int WS_HIDE = 0;//窗口隐藏
            //const int WS_SHOWNORMAL = 1;//窗口处于正常状态
            //const int WS_SHOWMIN = 2;//窗口处于最小化状态
            const int WS_SHOWMAX = 3;//窗口处于最大化状态
            ShowWindowAsync(process.MainWindowHandle, WS_SHOWMAX);
            //放到前端
            SetForegroundWindow(process.MainWindowHandle);
        }

        /// <summary>
        /// 该函数设置由不同线程产生的窗口的显示状态
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="cmdShow">指定窗口如何显示。查看允许值列表，请查阅ShowWlndow函数的说明部分</param>
        /// <returns>如果函数原来可见，返回值为非零；如果函数原来被隐藏，返回值为零</returns>
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        /// <summary>
        /// 该函数将创建指定窗口的线程设置到前台，并且激活该窗口。
        /// 键盘输入转向该窗口，并为用户改各种可视的记号。
        /// 系统给创建前台窗口的线程分配的权限稍高于其他线程。
        /// </summary>
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄</param>
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零</returns>
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
