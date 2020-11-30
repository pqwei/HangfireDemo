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
    /// 定时任务执行(Recurring jobs)
    /// </summary>
    public static class CycleJob
    {
        // <summary>
        /// 创建/更新名称为jobId,周期性为cronType的任务
        ///</summary>
        public static void AddOrUpdate(string jobId, Expression<Func<Task>> expression, string cronType)
        {
            RecurringJob.AddOrUpdate(jobId, expression, cronType, TimeZoneInfo.Local);
        }

        // <summary>
        /// 创建/更新名称为jobId,周期性为cronType的任务
        ///</summary>
        public static void AddOrUpdate(string jobId, Expression<Action> expression, string cronType)
        {
            RecurringJob.AddOrUpdate(jobId, expression, cronType, TimeZoneInfo.Local);
        }

        /// <summary>
        /// 删除job
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public static ResponseModel<bool> Delete(string jobId)
        {
            var result = BackgroundJob.Delete(jobId);
            return result.ToResponseModel(result);
        }

    }
}
