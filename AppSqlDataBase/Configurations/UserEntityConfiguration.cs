using System;
using AppCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSqlDataBase.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> entity)
        {
            #region Property
            entity.Property(e => e.FirstName)
                .HasMaxLength(50);

            entity.Property(e => e.LastName)
                .HasMaxLength(50);

            entity.Property(e => e.NationalityCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Ignore(e => e.ImageFile);
               

            #endregion

            #region Relational Property
            entity.HasMany(u => u.CustomerAddresses)
                .WithOne(ca => ca.User)
                .HasForeignKey(ca => ca.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(u => u.Offers)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Seed Data
            #endregion
        }
    }
}

