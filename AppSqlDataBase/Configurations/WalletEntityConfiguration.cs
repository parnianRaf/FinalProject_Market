using System;
using AppCore;
using Microsoft.EntityFrameworkCore;

namespace AppSqlDataBase.Configurations
{
    public class WalletEntityConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Wallet> entity)
        {
            #region Property
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId)
                .ValueGeneratedNever();

            entity.Property(e => e.Credit)
                .HasColumnType("decimal(10, 2)");
            #endregion

            #region Relational Property
            entity.HasOne(d => d.User)
                .WithOne(p => p.Wallet)
                .HasForeignKey<User>(w=>w.UserId);
            #endregion
        }
    }
}

