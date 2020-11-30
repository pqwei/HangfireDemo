using Hangfire;
using HangfireDemo.Common;
using HangfireDemo.Handlers;
using HangfireDemo.Jobs;
using HangfireDemo.Jobs.JobHelper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HangfireDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        [HttpGet("AddOrUpdateCycleJob")]
        public ResponseModel<string> AddOrUpdateCycleJob(string jobId)
        {
            Expression<Action> expression = () => JobHandler.AddOrUpdateCycleJob();
            CycleJob.AddOrUpdate(jobId, expression, CycleCronType.Minute());
            return string.Empty.ToResponseModel();
        }

        [HttpDelete("DeleteCycleJob")]
        public ResponseModel<bool> DeleteCycleJob(string jobId)
        {
            if (!int.TryParse(jobId, out int result))
            {
                return false.ToResponseModel("jobId格式不正确，必须为数字");
            }
            return CycleJob.Delete(jobId);
        }

        [HttpGet("AddOrUpdateDelayedJob")]
        public ResponseModel<string> AddOrUpdateDelayedJob()
        {
            Expression<Action> expression = () => JobHandler.AddOrUpdateDelayedJob();
            return DelayedJob.AddOrUpdate(expression, 10);
        }

        [HttpGet("AddOrUpdateQueueJob")]
        public ResponseModel<string> AddOrUpdateQueueJob()
        {
            Expression<Action> expression = () => JobHandler.AddOrUpdateQueueJob();
            return QueueJob.AddOrUpdate(expression);
        }

        [HttpGet("AddOrUpdateContinueJob")]
        public ResponseModel<string> AddOrUpdateContinueJob(string parentId)
        {
            Expression<Action> expression = () => JobHandler.AddOrUpdateContinueJob();
            return ContinueJob.AddOrUpdate(parentId, expression);
        }

    }
}
