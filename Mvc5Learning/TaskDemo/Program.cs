using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(() => {
                Thread.Sleep(1000);
                PrintTaskInfo("task1");
            });
            task1.Start();
            Task task2 = Task.Factory.StartNew(() => {
                Thread.Sleep(2000);
                PrintTaskInfo("task2");
            });
            //task2.Start();
            Task task3 = Task.Run(() => {
                Thread.Sleep(3000);
                PrintTaskInfo("task3");
            });
            //task3.Start();
            Console.WriteLine("主线程接受一个输入：");
            Console.ReadKey();
        }

        private static void PrintTaskInfo(string taskName)
        {
            Console.WriteLine($"taskName: {taskName}");
            Console.WriteLine($"ThreadPID: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
