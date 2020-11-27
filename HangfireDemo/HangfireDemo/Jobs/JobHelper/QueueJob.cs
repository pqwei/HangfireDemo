using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HangfireDemo.Jobs.JobHelper
{
    /// <summary>
    /// 基于队列的任务处理(Fire-and-forget jobs)
    /// </summary>
    public static class QueueJob
    {
        /// <summary>
        /// 创建队列任务
        /// </summary>
        /// <param name="expression">执行的函数</param>
        public static void AddOrUpdate(Expression<Func<Task>> expression)
        {
            BackgroundJob.Enqueue(expression);
        }

        /// <summary>
        /// 创建队列任务
        /// </summary>
        /// <param name="expression">执行的函数</param>
        public static string AddOrUpdate(Expression<Action> expression)
        {
            string workName = BackgroundJob.Enqueue(expression);
            return workName;
        }

    }

}
