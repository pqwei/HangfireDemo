using Hangfire;
using HangfireDemo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HangfireDemo.Common.JobHelper
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
        public static ResponseModel<string> AddOrUpdate(Expression<Func<Task>> expression, int minute)
        {
            string jobId =BackgroundJob.Schedule(expression, TimeSpan.FromMinutes(minute));
            return jobId.ToResponseModel();
        }


        /// <summary>
        /// 创建延迟任务
        /// </summary>
        /// <param name="expression">执行的函数</param>
        /// <param name="minute">延迟的分钟数</param>
        public static ResponseModel<string> AddOrUpdate(Expression<Action> expression, int minute)
        {
            string jobId = BackgroundJob.Schedule(expression, TimeSpan.FromMinutes(minute));
            return jobId.ToResponseModel();
        }

    }
}
