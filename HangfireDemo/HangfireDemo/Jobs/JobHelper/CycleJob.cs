using Hangfire;
using HangfireDemo.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HangfireDemo.Jobs.JobHelper
{
    /// <summary>
    /// 定时任务执行(Recurring jobs)
    /// </summary>
    public static class CycleJob
    {
        // <summary>
        /// 创建/更新名称为workName,周期性为cronType的任务
        ///</summary>
        public static void AddOrUpdate(string workName, Expression<Func<Task>> expression, string cronType)
        {
            RecurringJob.AddOrUpdate(workName, expression, cronType, TimeZoneInfo.Local);
        }

        // <summary>
        /// 创建/更新名称为workName,周期性为cronType的任务
        ///</summary>
        public static void AddOrUpdate(string workName, Expression<Action> expression, string cronType)
        {
            RecurringJob.AddOrUpdate(workName, expression, cronType, TimeZoneInfo.Local);
        }
    }
}
