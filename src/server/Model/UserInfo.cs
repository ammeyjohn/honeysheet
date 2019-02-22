using System;
using System.Collections.Generic;
using System.Text;

namespace HoneySheet.Model
{
    /// <summary>
    /// 定义用户信息对象
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 获取或设置用户姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置用户账号名
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 获取或设置用户头衔
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置所属部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 获取或设置用户对应经理账号
        /// </summary>
        public string ManagerAccount { get; set; }

        /// <summary>
        /// 获取或设置用户移动电话号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 获取或设置用户分机号
        /// </summary>
        public string ExtensionNumber { get; set; }

        /// <summary>
        /// 获取或设置用户电子邮件地址
        /// </summary>
        public string Email { get; set; }
    }
}
