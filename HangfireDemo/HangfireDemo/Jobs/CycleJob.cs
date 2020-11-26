using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HangfireDemo.Jobs
{
    /// <summary>
    /// 周期性任务
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
