using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireDemo.Models
{
    /// <summary>
    /// 定时Job表
    /// </summary>
    public class CycleJob
    {
        /// <summary>
        /// 定时Job表
        /// </summary>
        public CycleJob()
        {
        }

        private System.Int32 _Id;
        /// <summary>
        /// JobId
        /// </summary>
        public System.Int32 Id { get { return this._Id; } set { this._Id = value; } }

        private System.String _JobName;
        /// <summary>
        /// Job名
        /// </summary>
        public System.String JobName { get { return this._JobName; } set { this._JobName = value; } }

        private System.String _CycleCron;
        /// <summary>
        /// Job执行规则
        /// </summary>
        public System.String CycleCron { get { return this._CycleCron; } set { this._CycleCron = value; } }

        private System.DateTime? _LastDateTime;
        /// <summary>
        /// Job最后一次执行时间
        /// </summary>
        public System.DateTime? LastDateTime { get { return this._LastDateTime; } set { this._LastDateTime = value; } }
    }
}
