using HoneySheet.EfCore.Models;
using Microsoft.Extensions.Configuration;
using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoneySheet.Service
{
    /// <summary>
    /// 定义LDAP域管理服务
    /// </summary>
    public class LdapService
    {
        public LdapService(IConfiguration configuration)
        {
            Host = configuration["Ldap:Server"];
            Port = Convert.ToInt32(configuration["Ldap:Port"]);
            BindDN = configuration["Ldap:BindDN"];
            BindPassword = configuration["Ldap:BindPassword"];
            BaseDC = configuration["Ldap:BaseDC"];
        }

        public static string Host { get; private set; }

        public static string BindDN { get; private set; }

        public static string BindPassword { get; private set; }

        public static int Port { get; private set; }

        public static string BaseDC { get; private set; }

        /// <summary>
        /// 定义需要从域控制器中读取的用户属性列表
        /// </summary>
        private readonly static string[] Attributes = new string[]
            { "sAMAccountName", "department", "displayName", "mail", "manager", "mobile", "title" };

        /// <summary>
        /// 验证用户在域中是否合法
        /// </summary>
        /// <param name="username">域用户名</param>
        /// <param name="password">域登录密码</param>
        /// <returns>如果用户验证通过返回true，否则返回false</returns>
        public bool Validate(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("username");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            try
            {
                using (var conn = new LdapConnection())
                {
                    conn.Connect(Host, Port);
                    conn.Bind($"{BindDN},{BaseDC}", BindPassword);
                    var entities =
                        conn.Search(BaseDC, LdapConnection.SCOPE_SUB,
                            $"(sAMAccountName={username})", new string[] { "sAMAccountName" }, false);
                    string userDn = null;
                    while (entities.hasMore())
                    {
                        var entity = entities.next();
                        var account = entity.getAttribute("sAMAccountName");                        
                        if (account != null && account.StringValue == username)
                        {
                            userDn = entity.DN;
                            if (string.IsNullOrWhiteSpace(userDn))
                                return false;
                            break;
                        }
                    }
                    conn.Bind(userDn, password);
                    conn.Disconnect();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 从域控制器获取用户信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>返回用户信息对象，如果用户账号不存在，返回NULL</returns>
        public UserInfo GetUserInfo(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("username");
            try
            {
                using (var conn = new LdapConnection())
                {
                    conn.Connect(Host, Port);
                    conn.Bind($"{BindDN},{BaseDC}", BindPassword);
                    var entities =
                        conn.Search(BaseDC, LdapConnection.SCOPE_SUB,
                            $"(sAMAccountName={username})", Attributes, false);
                    while (entities.hasMore())
                    {
                        var entity = entities.next();
                        var user = new UserInfo();
                        user.Account = entity.getAttribute("sAMAccountName").StringValue;
                        user.Name = entity.getAttribute("displayName").StringValue;
                        user.Title = entity.getAttribute("title").StringValue;
                        user.Department = entity.getAttribute("department").StringValue;
                        user.Mobile = entity.getAttribute("mobile").StringValue;
                        user.Email = entity.getAttribute("mail").StringValue;
                        user.ManagerAccount = entity.getAttribute("manager").StringValue;
                        return user;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
