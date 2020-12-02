using HangfireDemo.Common.JobHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HangfireDemo.Handlers
{
    /// <summary>
    /// Job处理程序
    /// </summary>
    public class JobHandler
    {
        public static void Invoke(string jobId)
        {
            //初始化job下所有task状态为未处理
            //根据jobId取没有父节点的task，加入待处理队列
            int taskId = 0;
            Expression<Action> expression = () => TaskHandler.Invoke(jobId, taskId, null);
            QueueJob.AddOrUpdate(expression);
        }
    }
}
