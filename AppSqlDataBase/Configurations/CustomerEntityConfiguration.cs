using System;
using AppCore;
using Microsoft.EntityFrameworkCore;

namespace AppSqlDataBase.Configurations
{
	public class CustomerEntityConfiguration:IEntityTypeConfiguration<Customer>
	{
	

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> entity)
        {
            #region Property
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedNever();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasMaxLength(50);

            entity.Property(e => e.LastName)
                .HasMaxLength(50);

            entity.Property(e => e.NationalityCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.PasswordHash)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11);

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            #endregion

            #region Relational Property
            entity.HasMany(c => c.DirectOrders)
                .WithOne(o => o.Customer)
                .HasForeignKey(c => c.CustomerId);
            #endregion

            #region Seed Data
            #endregion
        }
    }
}

