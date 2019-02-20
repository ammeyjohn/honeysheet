using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneySheet.EntityFrameworkCore.Models
{
    public partial class Contract
    {
        public Contract()
        {
            Project = new HashSet<Project>();
        }

        public int ContractId { get; set; }
        [Required]
        [StringLength(20)]
        public string ContractCode { get; set; }
        [Required]
        [StringLength(50)]
        public string ContractName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ContractAmount { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfSign { get; set; }
        [Required]
        [StringLength(20)]
        public string Department { get; set; }
        [Required]
        [StringLength(20)]
        public string Salesman { get; set; }
        [StringLength(20)]
        public string Province { get; set; }
        public string Details { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [StringLength(20)]
        public string CreateUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [StringLength(20)]
        public string UpdateUser { get; set; }

        [InverseProperty("Contract")]
        public virtual ICollection<Project> Project { get; set; }
    }
}
