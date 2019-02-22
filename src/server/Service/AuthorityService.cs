using HoneySheet.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HoneySheet.Service
{
    /// <summary>
    /// 定义用户权限管理服务
    /// </summary>
    public class AuthorityService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="info">用户登录信息</param>
        /// <returns>返回用户登录证书对象</returns>
        public Credential Login(LoginInfo info)
        {
            var ldap = new LdapService();
            var cred = new Credential();
            var result = ldap.Validate(info.UserName, info.Password);
            if (result)
            {
                var user = ldap.GetLdapUserInfo(info.UserName);
                if (user != null)
                {
                    cred.User = user;
                    cred.LoginSuccess = true;
                    cred.LoginTime = DateTime.Now;
                }
            }
            return cred;
        }
    }
}
