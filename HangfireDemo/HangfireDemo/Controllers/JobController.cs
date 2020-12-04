using Hangfire;
using HangfireDemo.Common;
using HangfireDemo.Common.JobHelper;
using HangfireDemo.Handlers;
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
            if (!string.IsNullOrEmpty(jobId))
            {
                throw new Exception("dfgfdgfd");
            }
            Expression<Action> expression = () => JobHandler.Invoke(jobId);
            CycleJob.AddOrUpdate(jobId, expression, CycleCronType.Minute());
            return string.Empty.ToResponseModel();
        }

        [HttpGet("InvokeTask")]
        public ResponseModel<string> InvokeTask(string jobId, int taskId, params object[] parameters)
        {
            TaskHandler.Invoke(jobId, taskId, parameters);
            return string.Empty.ToResponseModel();
        }

        [HttpDelete("DeleteJob")]
        public ResponseModel<bool> DeleteJob(string jobId)
        {
            if (!int.TryParse(jobId, out int num))
            {
                return false.ToResponseModel("jobId格式不正确，必须为数字");
            }
            var result = BackgroundJob.Delete(jobId);
            return result.ToResponseModel(result);
        }
    }
}
