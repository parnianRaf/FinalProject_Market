using System;
using AppCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSqlDataBase.Configurations
{
    public class ProductsEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            #region Property
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedNever();

            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)");

            entity.Property(e => e.ProductName)
                .HasMaxLength(50);

            entity.Ignore(e => e.ImageFiles);
                
            #endregion

            #region Relational Property
            entity.HasOne(d => d.Auction)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.AuctionId)
                .HasConstraintName("FK_Product_Auction");

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.DirectOrder).
                WithMany(p => p.Products)
                .HasForeignKey(d => d.DirectOrderId)
                .HasConstraintName("FK_Product_ShoppingCart");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Product_Seller");
            #endregion

            #region Seed Data
            #endregion
        }
    }
}

