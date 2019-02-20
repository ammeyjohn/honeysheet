using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneySheet.EntityFrameworkCore.Models
{
    public partial class Project
    {
        public Project()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int ProjectId { get; set; }
        public int ContractId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProjectName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProjectAmount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateTime { get; set; }
        [Required]
        [StringLength(20)]
        public string CreateUser { get; set; }

        [ForeignKey("ContractId")]
        [InverseProperty("Project")]
        public virtual Contract Contract { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
