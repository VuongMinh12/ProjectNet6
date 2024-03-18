using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication3.Models
{
    public partial class KeyboardContext : DbContext
    {
        public KeyboardContext()
        {
        }

        public KeyboardContext(DbContextOptions<KeyboardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<PermissionRole> PermissionRoles { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductDetail> ProductDetails { get; set; } = null!;
        public virtual DbSet<Quanlity> Quanlities { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<ShopCart> ShopCarts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("KeyboardDbString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandName).HasMaxLength(255);

                entity.Property(e => e.Description).HasColumnType("ntext");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).HasMaxLength(255);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.ColorName).HasMaxLength(255);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Del).HasColumnName("DEL");

                entity.Property(e => e.Get).HasColumnName("GET");

                entity.Property(e => e.Post).HasColumnName("POST");

                entity.Property(e => e.Put).HasColumnName("PUT");
            });

            modelBuilder.Entity<PermissionRole>(entity =>
            {
                entity.ToTable("PermissionRole");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionRoles)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__Permissio__Permi__2F10007B");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Permissio__RoleI__2E1BDC42");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.ProductWeigt).HasColumnType("decimal(7, 3)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Product__BrandId__38996AB5");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__Categor__37A5467C");
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.ToTable("ProductDetail");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK__ProductDe__Color__3E52440B");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductDe__Produ__3D5E1FD2");

                entity.HasOne(d => d.Quanlity)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.QuanlityId)
                    .HasConstraintName("FK__ProductDe__Quanl__3F466844");
            });

            modelBuilder.Entity<Quanlity>(entity =>
            {
                entity.ToTable("Quanlity");

                entity.Property(e => e.QuanlityName).HasMaxLength(255);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShopCart>(entity =>
            {
                entity.ToTable("ShopCart");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShopCarts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ShopCart__Produc__4316F928");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShopCarts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ShopCart__UserId__4222D4EF");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserRole__RoleId__286302EC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRole__UserId__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
