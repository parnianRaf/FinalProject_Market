using System;
using AppCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSqlDataBase.Configurations
{
	public class CustomerAddressEntityConfiguration:IEntityTypeConfiguration<CustomerAddress>
	{
	

        public void Configure(EntityTypeBuilder<CustomerAddress> entity)
        {
            #region Property
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedNever();

            entity.Property(e => e.AddressTitle)
                .HasMaxLength(50);

            entity.Property(e => e.FullAddress)
                .HasMaxLength(150);
            #endregion

            #region Relational Property

            #endregion

            #region Seed Data
            #endregion
        }
    }
}

