using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WPF_MYSQL_EF2.Models;

public partial class ApplicationContext : DbContext
{
    private readonly string csom;
    public ApplicationContext()
    {
        var builder = new MySqlConnectionStringBuilder
        {
            Server = "127.0.0.1",
            Port = 3306,
            Database = "mfo",
            UserID = "myuser",
            Password = Environment.GetEnvironmentVariable("CSOM")
        };

        csom = builder.ConnectionString;
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Store> Stores { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(csom, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.ProductId, "idx_product_id");

            entity.HasIndex(e => e.StoreId, "idx_store_id");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.AmountDelivered).HasColumnName("amount_delivered");
            entity.Property(e => e.AmountOrdered).HasColumnName("amount_ordered");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_id");

            entity.HasOne(d => d.Store).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_store_id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("products");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.PriceOne).HasColumnName("price_one");
            entity.Property(e => e.ProductFat)
                .HasPrecision(5, 2)
                .HasColumnName("product_fat");
            entity.Property(e => e.ProductName)
                .HasMaxLength(45)
                .HasColumnName("product_name");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PRIMARY");

            entity.ToTable("stores");

            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.StoreAdress)
                .HasMaxLength(45)
                .HasColumnName("store_adress");
            entity.Property(e => e.StoreCeo)
                .HasMaxLength(45)
                .HasColumnName("store_ceo");
            entity.Property(e => e.StoreName)
                .HasMaxLength(45)
                .HasColumnName("store_name");
            entity.Property(e => e.StoreRegion)
                .HasMaxLength(45)
                .HasColumnName("store_region");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
