using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(20)]
        public string DepartmentName { get; set; }
    }
}
