using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExtraaEdge_MobileStore_Assignment.Models
{
    public partial class ExtraaEdge_TaskContext : DbContext
    {
        public ExtraaEdge_TaskContext()
        {
        }

        public ExtraaEdge_TaskContext(DbContextOptions<ExtraaEdge_TaskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBrand> TblBrands { get; set; } = null!;
        public virtual DbSet<TblCustomer> TblCustomers { get; set; } = null!;
        public virtual DbSet<TblMobileBrand> TblMobileBrands { get; set; } = null!;
        public virtual DbSet<TblMobileSale> TblMobileSales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-7M7BRBEI;Database=ExtraaEdge_Task;trusted_Connection=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBrand>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK__tblBrand__5E5A8E27CEE74C31");

                entity.ToTable("tblBrands");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.Barnd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("barnd");
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__tblCusto__CD65CB85B06FFE60");

                entity.ToTable("tblCustomers");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Last_name");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mobile_number");
            });

            modelBuilder.Entity<TblMobileBrand>(entity =>
            {
                entity.HasKey(e => e.MobileId)
                    .HasName("PK__tblMobil__D7B1D91F7BF17250");

                entity.ToTable("tblMobileBrands");

                entity.Property(e => e.MobileId).HasColumnName("mobile_id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.TblMobileBrands)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("fkbrandid");
            });

            modelBuilder.Entity<TblMobileSale>(entity =>
            {
                entity.HasKey(e => e.SaleId)
                    .HasName("PK__tblMobil__FB9024C71A66C5ED");

                entity.ToTable("tblMobileSales");

                entity.Property(e => e.SaleId).HasColumnName("Sale_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.MobileId).HasColumnName("mobile_id");

                entity.Property(e => e.SaleAmount).HasColumnName("sale_amount");

                entity.Property(e => e.SaleDate)
                    .HasColumnType("date")
                    .HasColumnName("Sale_date");

                entity.Property(e => e.SaleQuantity).HasColumnName("sale_quantity");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblMobileSales)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fkcustid");

                entity.HasOne(d => d.Mobile)
                    .WithMany(p => p.TblMobileSales)
                    .HasForeignKey(d => d.MobileId)
                    .HasConstraintName("fkmobileid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
