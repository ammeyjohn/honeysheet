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
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=128.1.2.236;Database=HoneySheet;Uid=sa;Password=p@ssw0rd");
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

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("Invoice_pk")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.CreateUser).IsUnicode(false);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Invoice_ProjectId_fk");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("Project_pk")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.CreateUser).IsUnicode(false);

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Project_ContractId_fk");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(e => e.ReceiptId)
                    .HasName("Receipt_pk")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.CreateUser).IsUnicode(false);

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Receipt_InvoiceId_fk");
            });
        }
    }
}
