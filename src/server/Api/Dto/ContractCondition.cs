using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneySheet.Api.Dto
{
    /// <summary>
    /// 定义合同查询条件对象
    /// </summary>
    public class ContractCondition
    {
        /// <summary>
        /// 获取或设置合同编码查询条件
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 获取或设置合同名称查询条件
        /// </summary>
        public string ContractName { get; set; }
    }
}
