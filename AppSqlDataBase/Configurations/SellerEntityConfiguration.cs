using System;
using AppCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSqlDataBase.Configurations
{
    public class SellerEntityConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> entity)
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
        }
    }
}

