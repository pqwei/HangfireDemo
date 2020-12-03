using HangfireDemo.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HangfireDemo.Enums
{
    public class LastStatusEnum
    {
        [Serializable, Description("最后一次执行状态"), DataContract]
        public enum LastStatus
        {
            [Description("未执行")]
            [EnumMember]
            Pending = 1,
            [Description("执行成功")]
            [EnumMember]
            Success = 2,
            [Description("执行失败")]
            [EnumMember]
            Fail = 3
        }

        public class CompanyAuditStatusEnumsDict
        {
            public static readonly Dictionary<int, string> CompanyAuditStatusEnumDict;
            public static readonly Dictionary<string, string> CompanyAuditStatusFieldDict;
            static CompanyAuditStatusEnumsDict()
            {
                CompanyAuditStatusEnumDict = EnumUtil.GetEnumIntNameDict(LastStatus.Pending);
                CompanyAuditStatusFieldDict = EnumUtil.GetEnumVarNameDict(LastStatus.Pending);
            }
        }
    }
}
