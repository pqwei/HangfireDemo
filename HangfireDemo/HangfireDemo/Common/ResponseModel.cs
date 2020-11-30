using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireDemo.Common
{
    /// <summary>
    /// 响应实体
    /// </summary>
    public class ResponseModel<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        private int _status = 500;
        public int status
        {
            get { return success ? 200 : _status; }
            set { _status = value; }
        }

        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = false;

        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T values { get; set; }

    }

    public static class ObjToReponseHelper
    {
        public static ResponseModel<T> ToResponseModel<T>(this T result, bool success = true, int status = 200)
        {
            return new ResponseModel<T>
            {
                success = success,
                status = status,
                values = result,
                msg = success ? "操作成功!" : "操作失败!"
            };
        }

        public static ResponseModel<T> ToResponseModel<T>(this T result, string msg, bool success = false, int status = 500)
        {
            return new ResponseModel<T>
            {
                success = success,
                status = status,
                values = result,
                msg = msg
            };
        }
    }
}
