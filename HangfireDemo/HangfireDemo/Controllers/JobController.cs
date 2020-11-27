using Hangfire;
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
        public string AddOrUpdateCycleJob(string workName)
        {
            Expression<Action> expression = () => JobHandler.AddOrUpdateCycleJob();
            CycleJob.AddOrUpdate(workName, expression, CycleCronType.Minute());
            return "AddOrUpdateCycleJob成功";
        }

        [HttpGet("AddOrUpdateDelayedJob")]
        public string AddOrUpdateDelayedJob()
        {
            Expression<Action> expression = () => JobHandler.AddOrUpdateDelayedJob();
            string workName = DelayedJob.AddOrUpdate(expression, 10);
            return $"AddOrUpdateDelayedJob成功,Jon名{workName}";
        }

        [HttpGet("AddOrUpdateQueueJob")]
        public string AddOrUpdateQueueJob()
        {
            Expression<Action> expression = () => JobHandler.AddOrUpdateQueueJob();
            string workName = QueueJob.AddOrUpdate(expression);
            return $"AddOrUpdateQueueJob成功,Jon名{workName}";
        }

        [HttpGet("AddOrUpdateContinueJob")]
        public string AddOrUpdateContinueJob(string parentId)
        {
            Expression<Action> expression = () => JobHandler.AddOrUpdateContinueJob();
            string workName = ContinueJob.AddOrUpdate(parentId, expression);
            return $"AddOrUpdateContinueJob成功,Jon名{workName}";
        }

    }
}
