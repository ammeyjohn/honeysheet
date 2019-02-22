using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(20)]
        public string Account { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
