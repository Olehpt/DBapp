using System;
using System.Collections.Generic;
using DBapp.Models;
using Microsoft.EntityFrameworkCore;

namespace DBapp.Data;

public partial class DB1Context : DbContext
{
    public DB1Context()
    {
    }

    public DB1Context(DbContextOptions<DB1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<DelieveryMethod> DelieveryMethods { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderState> OrderStates { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductStatus> ProductStatuses { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<SellerAccount> SellerAccounts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WishlistItem> WishlistItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=USER-PK\\SQLEXPRESS;Database=DB1;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.Property(e => e.CartItemId)
                .ValueGeneratedNever()
                .HasColumnName("CartItemID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartItems_Product");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.DisplayName).HasMaxLength(50);
        });

        modelBuilder.Entity<DelieveryMethod>(entity =>
        {
            entity.Property(e => e.DelieveryMethodId)
                .ValueGeneratedNever()
                .HasColumnName("DelieveryMethodID");
            entity.Property(e => e.DisplayName).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DelieveryMethodId).HasColumnName("DelieveryMethodID");
            entity.Property(e => e.OrderStateId).HasColumnName("OrderStateID");
            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.DelieveryMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DelieveryMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_DelieveryMethod");

            entity.HasOne(d => d.OrderState).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_OrderState");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_PaymentMethod");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_User");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.Property(e => e.OrderItemId)
                .ValueGeneratedNever()
                .HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Product");
        });

        modelBuilder.Entity<OrderState>(entity =>
        {
            entity.Property(e => e.OrderStateId)
                .ValueGeneratedNever()
                .HasColumnName("OrderStateID");
            entity.Property(e => e.DisplayName).HasMaxLength(50);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.Property(e => e.PaymentMethodId)
                .ValueGeneratedNever()
                .HasColumnName("PaymentMethodID");
            entity.Property(e => e.DisplayName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastEditDate).HasColumnType("datetime");
            entity.Property(e => e.ProductStatusId).HasColumnName("ProductStatusID");
            entity.Property(e => e.SellerId).HasColumnName("SellerID");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Category");

            entity.HasOne(d => d.ProductStatus).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductStatus");

            entity.HasOne(d => d.Seller).WithMany(p => p.Products)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Seller");
        });

        modelBuilder.Entity<ProductStatus>(entity =>
        {
            entity.Property(e => e.ProductStatusId)
                .ValueGeneratedNever()
                .HasColumnName("ProductStatusID");
            entity.Property(e => e.DisplayName).HasMaxLength(50);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("ReviewID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.DisplayName).HasMaxLength(50);
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.Property(e => e.SellerId)
                .ValueGeneratedNever()
                .HasColumnName("SellerID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DisplayName).HasMaxLength(50);
            entity.Property(e => e.LastEditDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SellerAccount>(entity =>
        {
            entity.HasIndex(e => e.UserId, "UQ_SellerAccount_UserId").IsUnique();

            entity.Property(e => e.SellerAccountId)
                .ValueGeneratedNever()
                .HasColumnName("SellerAccountID");
            entity.Property(e => e.SellerId).HasColumnName("SellerID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Seller).WithMany(p => p.SellerAccounts)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SellerAccounts_Seller");

            entity.HasOne(d => d.User).WithOne(p => p.SellerAccount)
                .HasForeignKey<SellerAccount>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SellerAccounts_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LastEditDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<WishlistItem>(entity =>
        {
            entity.Property(e => e.WishlistItemId)
                .ValueGeneratedNever()
                .HasColumnName("WishlistItemID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.WishlistItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WishlistItems_Product");

            entity.HasOne(d => d.User).WithMany(p => p.WishlistItems)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WishlistItems_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
