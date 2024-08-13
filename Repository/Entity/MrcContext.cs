﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Entity;

public partial class MrcContext : DbContext
{
    public MrcContext()
    {
    }

    public MrcContext(DbContextOptions<MrcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=QUANGHUY\\QHUY;database=MRC;user=sa;password=12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3213E83F7E91D615");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Image__3213E83F81CDEAC7");

            entity.ToTable("Image");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LinkImage)
                .HasMaxLength(255)
                .HasColumnName("linkImage");
            entity.Property(e => e.ProductId).HasColumnName("productId");

            entity.HasOne(d => d.Product).WithMany(p => p.Images)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Image__productId__412EB0B6");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3213E83F1F39A9ED");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("createDate");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalPrice");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Order__userId__440B1D61");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3213E83FACD9307B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__order__47DBAE45");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__produ__46E78A0C");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3213E83F30DB6A16");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.ImageId).HasColumnName("imageID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("productName");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__categor__3E52440B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83F97239305");

            entity.ToTable("User");

            entity.HasIndex(e => e.UserName, "User_index_0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
