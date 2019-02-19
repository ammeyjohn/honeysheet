using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HoneySheet.EntityFrameworkCore.Models
{
    public partial class HoneySheetContext : DbContext
    {
        public HoneySheetContext()
        {
        }

        public HoneySheetContext(DbContextOptions<HoneySheetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contract> Contract { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=HoneySheet;Uid=sa;Password=p@ssw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.ContractCode).IsUnicode(false);

                entity.Property(e => e.CreateUser).IsUnicode(false);

                entity.Property(e => e.Province).IsUnicode(false);

                entity.Property(e => e.UpdateUser).IsUnicode(false);
            });
        }
    }
}
