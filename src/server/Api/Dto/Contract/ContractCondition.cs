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
        /// 获取或设置合同编号查询列表
        /// </summary>
        public int[] ContractIds { get; set; }

        /// <summary>
        /// 获取或设置合同编码查询条件
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 获取或设置合同名称查询条件
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// 获取或设置合同签订日期查询条件0
        /// </summary>
        public DateTime? DateOfSign0 { get; set; }

        /// <summary>
        /// 获取或设置合同签订日期查询条件1
        /// </summary>
        public DateTime? DateOfSign1 { get; set; }

        /// <summary>
        /// 获取或设置合同金额查询条件0
        /// </summary>
        public decimal? ContractAmount0 { get; set; }

        /// <summary>
        /// 获取或设置合同金额查询条件1
        /// </summary>
        public decimal? ContractAmount1 { get; set; }

        /// <summary>
        /// 获取或设置销售人查询列表
        /// </summary>
        public string[] Salesmans { get; set; }

        /// <summary>
        /// 获取或设置合同所述部门列表
        /// </summary>
        public int[] DepartmentIds { get; set; }
    }
}
