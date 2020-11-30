using HangfireDemo.Common.JobHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HangfireDemo.Handlers
{
    public class TaskHandler
    {
        private static readonly object obj = new object();
        /// <summary>
        /// DataCalculate节点
        /// </summary>
        public static List<string> DataCalculateNodes = new List<string>();

        /// <summary>
        /// 执行Task
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="parameter"></param>
        public static void Invoke(int taskId, object parameter)
        {
            string dataCalculateNode = string.Empty;
            DataCalculateNodes = new List<string>() { "asfsdf" };
            //加锁，保证DataCalculate节点单线程运行
            lock (obj)
            {
                while (true)
                {
                    if (DataCalculateNodes.Count > 0)
                    {
                        dataCalculateNode = DataCalculateNodes.FirstOrDefault();
                        if (!string.IsNullOrEmpty(dataCalculateNode))
                        {
                            break;
                        }
                    }
                    Thread.Sleep(1000);
                }
            }

            var isSuccess = InvokeDataCalculate(dataCalculateNode, taskId, parameter);
            if (!isSuccess)
            {
                //dataCalculateNode节点执行方法
                //成功的话，取子task加入队列
                Expression<Action> expression = () => Invoke(taskId, null);
                var jobId = QueueJob.AddOrUpdate(expression);
            }
        }

        /// <summary>
        /// 执行DataCalculate
        /// </summary>
        /// <param name="dataCalculateNode"></param>
        /// <param name="taskId"></param>
        /// <param name="parameter"></param>
        private static bool InvokeDataCalculate(string dataCalculateNode, int taskId, object parameter)
        {
            return true;
        }
    }
}
