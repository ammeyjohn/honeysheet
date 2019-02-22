using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneySheet.Model
{
    /// <summary>
    /// 定义用户登录信息
    /// </summary>
    public class LoginInfo
    {
        /// <summary>
        /// 获取或设置用户账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 获取或设置用户登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置用户登录机器标识
        /// </summary>
        public string ClientCode { get; set; }
    }
}
