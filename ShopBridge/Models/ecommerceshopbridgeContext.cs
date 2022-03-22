using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShopBridge.Models
{
    public partial class ecommerceshopbridgeContext : DbContext
    {
        public ecommerceshopbridgeContext()
        {
        }

        public ecommerceshopbridgeContext(DbContextOptions<ecommerceshopbridgeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admintbl> Admintbl { get; set; }
        public virtual DbSet<Categorytbl> Categorytbl { get; set; }
        public virtual DbSet<Contacttbl> Contacttbl { get; set; }
        public virtual DbSet<Producttbl> Producttbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DELL;Database=ecommerceshopbridge;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admintbl>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.Property(e => e.AdminId)
                    .HasColumnName("Admin_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Categorytbl>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("Category_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Contacttbl>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(10);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(10);

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Producttbl>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.ProductDesc)
                    .IsRequired()
                    .HasColumnName("Product_Desc");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("Product_Name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Producttbl)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producttbl_Categorytbl");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
