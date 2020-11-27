using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HangfireDemo.Jobs.JobHelper
{
    /// <summary>
    /// 延迟任务执行(Delayed jobs)
    /// </summary>
    public static class DelayedJob
    {
        /// <summary>
        /// 创建延迟任务
        /// </summary>
        /// <param name="expression">执行的函数</param>
        /// <param name="minute">延迟的分钟数</param>
        public static void AddOrUpdate(Expression<Func<Task>> expression, int minute)
        {
            BackgroundJob.Schedule(expression, TimeSpan.FromMinutes(minute));
        }


        /// <summary>
        /// 创建延迟任务
        /// </summary>
        /// <param name="expression">执行的函数</param>
        /// <param name="minute">延迟的分钟数</param>
        public static string AddOrUpdate(Expression<Action> expression, int minute)
        {
            string workName = BackgroundJob.Schedule(expression, TimeSpan.FromMinutes(minute));
            return workName;
        }

    }
}
