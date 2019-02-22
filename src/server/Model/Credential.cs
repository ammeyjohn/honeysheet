using System;
using System.Collections.Generic;
using System.Text;

namespace HoneySheet.Model
{
    /// <summary>
    /// 定义用户登录证书对象
    /// </summary>
    public class Credential
    {        
        public Credential()
        {
            this.LoginSuccess = true;
            this.LoginTime = DateTime.Now;
        }

        /// <summary>
        /// 获取或设置用户信息
        /// </summary>
        public UserInfo User { get; set; }

        /// <summary>
        /// 获取或设置用户登录是否成功标志
        /// </summary>
        public bool LoginSuccess { get; set; }

        /// <summary>
        /// 获取或设置用户成功登陆时间
        /// </summary>
        public DateTime? LoginTime { get; set; }
    }
}
