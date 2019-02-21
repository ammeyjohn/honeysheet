using HoneySheet.EfCore.Models;
using Microsoft.Extensions.Configuration;
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
        public AuthorityService(LdapService ldap)
        {
            this._ldap = ldap;
        }

        private LdapService _ldap;

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="info">用户登录信息</param>
        /// <returns>返回用户登录证书对象</returns>
        public Credential Login(LoginInfo info)
        {            
            var result = _ldap.Validate(info.UserName, info.Password);
            return null;
        }
    }
}
