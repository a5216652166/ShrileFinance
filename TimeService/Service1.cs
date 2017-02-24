using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;
using Application;

namespace TimeService
{
    public partial class Service1 : ServiceBase
    {
        private TimeAppService timeAppService;

        // 计时器
        Timer timer;
        public Service1()
        {
            InitializeComponent();
            timeAppService = new TimeAppService();
        }

        protected override void OnStart(string[] args)
        {
            //测试暂时定一分钟检测一次，正式上线后改为每天检测一次（每天晚上十二点）
            timer = new Timer(60000);
            timer.Elapsed += new ElapsedEventHandler(Time_StartElapsed);
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Elapsed += new ElapsedEventHandler(Timer_StopElapsed);

            timer.Stop();
            timer.Dispose();
        }

        void Timer_StopElapsed(object sender, ElapsedEventArgs e)
        {
            //string filePath = AppDomain.CurrentDomain.BaseDirectory + "test.txt";
            string filePath = "D:/baa.txt";

            StreamWriter sw = null;
            if (!File.Exists(filePath))
            {
                sw = File.CreateText(filePath);
            }
            else
            {
                sw = File.AppendText(filePath);
            }
            sw.Write("访问时间：" + DateTime.Now.ToString() + Environment.NewLine);
            sw.Close();
        }
        public void Time_StartElapsed(object sender, ElapsedEventArgs e)
        {
            timeAppService.TimeService();
        }
    }
}
