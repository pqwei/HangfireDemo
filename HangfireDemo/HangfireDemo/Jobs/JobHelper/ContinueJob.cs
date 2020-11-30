using Hangfire;
using HangfireDemo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HangfireDemo.Jobs.JobHelper
{
    /// <summary>
    /// 延续性任务执行(Continuations)
    /// </summary>
    public class ContinueJob
    {

        // <summary>
        /// 创建/更新父节点名称为parentId的任务
        ///</summary>
        public static ResponseModel<string> AddOrUpdate(string parentId, Expression<Func<Task>> expression)
        {
            string jobId = BackgroundJob.ContinueJobWith(parentId, expression);
            return jobId.ToResponseModel();
        }

        /// <summary>
        /// 创建/更新父节点名称为parentId的任务
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static ResponseModel<string> AddOrUpdate(string parentId, Expression<Action> expression)
        {
            string jobId = BackgroundJob.ContinueJobWith(parentId, expression);
            return jobId.ToResponseModel();
        }
    }
}
