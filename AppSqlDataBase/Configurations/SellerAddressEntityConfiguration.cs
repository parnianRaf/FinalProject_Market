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
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId)
                .ValueGeneratedNever();

            entity.Property(e => e.AddressTitle)
                .HasMaxLength(50);

            entity.Property(e => e.FullAddress)
                .HasMaxLength(150);
            #endregion

            #region Relational Property
            entity.HasOne(d => d.User)
                .WithOne(p => p.SellerAddress)
                .HasForeignKey<SellerAddress>(d=>d.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Seed Data
            #endregion
        }
    }
}

