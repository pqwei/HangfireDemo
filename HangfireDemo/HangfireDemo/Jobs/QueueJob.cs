using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HangfireDemo.Jobs
{
    /// <summary>
    /// 队列任务
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
        public static void AddOrUpdate(Expression<Action> expression)
        {
            BackgroundJob.Enqueue(expression);
        }

    }

}
