using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireDemo.Models
{
    /// <summary>
    /// 定时Job任务表
    /// </summary>
    public class CycleJobTask
    {
        /// <summary>
        /// 定时Job任务表
        /// </summary>
        public CycleJobTask()
        {
        }

        private System.Int32 _Id;
        /// <summary>
        /// 定时Job任务Id
        /// </summary>
        public System.Int32 Id { get { return this._Id; } set { this._Id = value; } }

        private System.Int32 _FK_CycleJob;
        /// <summary>
        /// 定时JobId
        /// </summary>
        public System.Int32 FK_CycleJob { get { return this._FK_CycleJob; } set { this._FK_CycleJob = value; } }

        private System.Int32 _FK_ParentTask;
        /// <summary>
        /// 父TaskId
        /// </summary>
        public System.Int32 FK_ParentTask { get { return this._FK_ParentTask; } set { this._FK_ParentTask = value; } }

        private System.DateTime? _LastDateTime;
        /// <summary>
        /// Job最后一次执行时间
        /// </summary>
        public System.DateTime? LastDateTime { get { return this._LastDateTime; } set { this._LastDateTime = value; } }

        private System.String _LastResult;
        /// <summary>
        /// 最后一次调用的结果
        /// </summary>
        public System.String LastResult { get { return this._LastResult; } set { this._LastResult = value; } }
    }
}
