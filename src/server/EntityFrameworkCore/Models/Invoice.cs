using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneySheet.EntityFrameworkCore.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            Receipt = new HashSet<Receipt>();
        }

        public int InvoiceId { get; set; }
        public int ProjectId { get; set; }
        [Column(TypeName = "date")]
        public DateTime DrawDate { get; set; }
        public int InvoiceType { get; set; }
        [Required]
        [StringLength(100)]
        public string InvoiceContent { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateTime { get; set; }
        [Required]
        [StringLength(20)]
        public string CreateUser { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("Invoice")]
        public virtual Project Project { get; set; }
        [InverseProperty("Invoice")]
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
