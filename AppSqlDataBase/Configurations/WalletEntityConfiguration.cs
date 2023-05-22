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
            entity.HasKey(e => e.CustomerId);

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever();

            entity.Property(e => e.Credit)
                .HasColumnType("decimal(10, 2)");
            #endregion

            #region Relational Property
            entity.HasOne(d => d.Customer)
                .WithOne(p => p.Wallet)
                .HasForeignKey<Wallet>(w=>w.CustomerId);
            #endregion
        }
    }
}

