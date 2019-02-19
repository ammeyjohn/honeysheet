using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        var builder = new ConfigurationBuilder();
        //        builder.
                   
        //        var configuration = builder.Build();
        //        optionsBuilder.UseSqlServer(configuration["ConnectionStrings:HoneySheet"]);
        //    }
        //}

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
