using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneySheet.Model.Dto
{
    /// <summary>
    /// 定义合同输出对象，仅返回合同名称以及合同编号
    /// </summary>
    public class ContractNameOutput
    {
        /// <summary>
        /// 获取或设置合同Id
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// 获取或设置合同编码
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 获取或设置合同名称
        /// </summary>
        public string ContractName { get; set; }
    }
}
