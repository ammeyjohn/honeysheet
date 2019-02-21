using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Models
{
    public partial class Receipt
    {
        public int ReceiptId { get; set; }
        public int InvoiceId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? PayDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PayAmount { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReceiptDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ReceiptAmount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateTime { get; set; }
        [Required]
        [StringLength(20)]
        public string CreateUser { get; set; }

        [ForeignKey("InvoiceId")]
        [InverseProperty("Receipt")]
        public virtual Invoice Invoice { get; set; }
    }
}
