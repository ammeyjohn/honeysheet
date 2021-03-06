//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HoneySheet.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contract()
        {
            this.Projects = new HashSet<Project>();
        }
    
        public int ContractId { get; set; }
        public string ContractCode { get; set; }
        public string ContractName { get; set; }
        public decimal ContractAmount { get; set; }
        public System.DateTime DateOfSign { get; set; }
        public int DepartmentId { get; set; }
        public string SalesAccount { get; set; }
        public int State { get; set; }
        public string Custom { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string UpdateUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Projects { get; set; }
        public virtual Department Department { get; set; }
        public virtual User Salesman { get; set; }
    }
}
