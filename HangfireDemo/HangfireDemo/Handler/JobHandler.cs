using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HangfireDemo.Handler
{
    /// <summary>
    /// Job处理程序
    /// </summary>
    public class JobHandler
    {
        public static void AddOrUpdateCycleJob(string jobId)
        {
            //根据jobId取没有父节点的task，加入待处理队列
        }

        public static void AddOrUpdateCycleJob()
        {
        }

        public static void AddOrUpdateDelayedJob()
        {
        }

        public static void AddOrUpdateQueueJob()
        {

        }

        public static void AddOrUpdateContinueJob()
        {

        }


    }
}
