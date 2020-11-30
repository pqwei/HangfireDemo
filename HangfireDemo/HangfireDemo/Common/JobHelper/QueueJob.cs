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
    /// 基于队列的任务处理(Fire-and-forget jobs)
    /// </summary>
    public static class QueueJob
    {
        /// <summary>
        /// 创建队列任务
        /// </summary>
        /// <param name="expression">执行的函数</param>
        public static ResponseModel<string> AddOrUpdate(Expression<Func<Task>> expression)
        {
            string jobId = BackgroundJob.Enqueue(expression);
            return jobId.ToResponseModel();
        }

        /// <summary>
        /// 创建队列任务
        /// </summary>
        /// <param name="expression">执行的函数</param>
        public static ResponseModel<string> AddOrUpdate(Expression<Action> expression)
        {
            string jobId = BackgroundJob.Enqueue(expression);
            return jobId.ToResponseModel();
        }
    }

}
