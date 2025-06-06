﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.models;

public partial class ShopContext : DbContext
{
    public ShopContext()
    {
    }

    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<ShopDetail> ShopDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=shop;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__Categori__6A1C8AFADB10114F");

            entity.Property(e => e.CatName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CompId).HasColumnName("compId");

            entity.HasOne(d => d.Comp).WithMany(p => p.Categories)
                .HasForeignKey(d => d.CompId)
                .HasConstraintName("FK__Categorie__compI__412EB0B6");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompId).HasName("PK__Companie__AD362A1697AF1B6D");

            entity.Property(e => e.CompName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__Customer__049E3AA9BF6245C1");

            entity.Property(e => e.CustId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProdId).HasName("PK__Products__042785E56B6C4F01");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProdName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.CatCodeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatCode)
                .HasConstraintName("FK__Products__CatCod__4222D4EF");

            entity.HasOne(d => d.CompanyCodeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CompanyCode)
                .HasConstraintName("FK__Products__Compan__440B1D61");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.ShopId).HasName("PK__Shop__67C557C96215760A");

            entity.ToTable("Shop");

            entity.Property(e => e.CustomerCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsPay).HasColumnName("isPay");
            entity.Property(e => e.ShopNote).HasColumnType("text");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CustomerCodeNavigation).WithMany(p => p.Shops)
                .HasForeignKey(d => d.CustomerCode)
                .HasConstraintName("FK__Shop__CustomerCo__45F365D3");
        });

        modelBuilder.Entity<ShopDetail>(entity =>
        {
            entity.HasKey(e => e.ShopDetailsId).HasName("PK__ShopDeta__A3F70B48247FC853");

            entity.HasOne(d => d.ProductCodeNavigation).WithMany(p => p.ShopDetails)
                .HasForeignKey(d => d.ProductCode)
                .HasConstraintName("FK__ShopDetai__Produ__47DBAE45");

            entity.HasOne(d => d.ShopCodeNavigation).WithMany(p => p.ShopDetails)
                .HasForeignKey(d => d.ShopCode)
                .HasConstraintName("FK__ShopDetai__ShopC__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
