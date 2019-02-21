using System;
using System.Collections.Generic;
using System.Text;

namespace HoneySheet.EfCore.Models
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
        /// 获取或设置登录账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 获取或设置用户姓名
        /// </summary>
        public string Name { get; set; }

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
