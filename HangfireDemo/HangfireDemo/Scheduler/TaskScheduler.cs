using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HangfireDemo.Scheduler
{
    /// <summary>
    /// Task调度器
    /// </summary>
    public class TaskScheduler
    {
        /// <summary>
        /// 待执行队列
        /// </summary>
        public Queue<dynamic> WaitInvokeQueue = new Queue<dynamic>();
        public List<string> DataCalculateNodes = new List<string>();
        public TaskScheduler()
        {
            Task.Run(Scheduling);
        }

        private void Scheduling()
        {
            while (true)
            {
                if (DataCalculateNodes.Count > 0)
                {
                    var dataCalculateNode = DataCalculateNodes.FirstOrDefault();
                    if (WaitInvokeQueue.Count() > 0)
                    {
                        var message = WaitInvokeQueue.Dequeue();
                        Invoke(dataCalculateNode, message);
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private void Invoke(string dataCalculateNode, dynamic message)
        {
            //dataCalculateNode节点执行方法
            //成功的话，取子task加入队列
        }
    }
}
