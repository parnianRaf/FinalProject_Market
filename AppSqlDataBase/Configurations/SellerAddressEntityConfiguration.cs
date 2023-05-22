using System;
using AppCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSqlDataBase.Configurations
{
	public class SellerAddressEntityConfiguration:IEntityTypeConfiguration<SellerAddress>
	{

        public void Configure(EntityTypeBuilder<SellerAddress> entity)
        {
            #region Property
            entity.HasKey(e => e.SellerId);

            entity.Property(e => e.SellerId)
                .ValueGeneratedNever();

            entity.Property(e => e.AddressTitle)
                .HasMaxLength(50);

            entity.Property(e => e.FullAddress)
                .HasMaxLength(150);
            #endregion

            #region Relational Property
            entity.HasOne(d => d.Seller)
                .WithOne(p => p.SellerAddress)
                .HasForeignKey<SellerAddress>(d=>d.SellerId);
            #endregion

            #region Seed Data
            #endregion
        }
    }
}

