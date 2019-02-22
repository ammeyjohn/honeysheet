using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Configuration;
using System.Text;
using HoneySheet.Model;

namespace HoneySheet.Service
{
    /// <summary>
    /// 定义LDAP域管理服务
    /// </summary>
    public class LdapService
    {
        static LdapService()
        {
            LdapPath = ConfigurationManager.AppSettings["LdapPath"];
            LdapUser = ConfigurationManager.AppSettings["UserCN"];
            LdapPassword = ConfigurationManager.AppSettings["Password"];
        }

        private static readonly string LdapPath = null;
        private static readonly string LdapUser = null;
        private static readonly string LdapPassword = null;

        /// <summary>
        /// LDAP用户认证
        /// </summary>
        /// <param name="userName">域用户名</param>
        /// <param name="password">登陆密码</param>
        /// <returns>如果验证通过返回true，否则返回false</returns>
        public bool Validate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            try
            {
                var entry = new DirectoryEntry(LdapPath, LdapUser, LdapPassword, AuthenticationTypes.None);
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = string.Format("(sAMAccountName={0})", userName);
                search.SearchScope = SearchScope.Subtree;

                SearchResult result = search.FindOne();
                if (result == null) return false;

                var property = result.Properties["distinguishedName"];

                var entry1 = new DirectoryEntry(LdapPath,
                    property[0].ToString(), password, AuthenticationTypes.None);
                var obj = entry1.NativeObject;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 从域控制器获取指定用户信息
        /// </summary>
        /// <param name="userName">域用户名</param>
        /// <returns>如果用户存在返回用户信息，否则返回NULL</returns>
        public UserInfo GetLdapUserInfo(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");

            try
            {
                var entry = new DirectoryEntry(LdapPath, LdapUser, LdapPassword, AuthenticationTypes.None);
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = string.Format("(sAMAccountName={0})", userName);
                search.SearchScope = SearchScope.Subtree;

                SearchResult result = search.FindOne();
                if (result == null) return null;

                var user = new UserInfo();
                user.Account = result.Properties["sAMAccountName"][0].ToString();
                user.Name = result.Properties["displayName"][0].ToString();
                user.Title = result.Properties["title"][0].ToString();
                user.Department = result.Properties["department"][0].ToString();
                user.Email = result.Properties["mail"][0].ToString();
                user.Mobile = result.Properties["mobile"][0].ToString();
                user.ManagerAccount = result.Properties["manager"][0].ToString();
                user.ExtensionNumber = result.Properties["physicalDeliveryOfficeName"][0].ToString();
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
