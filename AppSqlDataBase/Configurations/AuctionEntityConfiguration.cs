using System;
using System.Reflection.Emit;
using AppCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSqlDataBase.Configurations
{
	public class AuctionEntityConfiguration:IEntityTypeConfiguration<Auction>
	{
        public void Configure(EntityTypeBuilder<Auction> entity)
        {
            #region Property
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedNever();

            entity.Property(e => e.FinalPrice)
                .HasColumnType("decimal(10, 2)");
            #endregion

            #region Relational Property
            #endregion

            #region Seed Data
            #endregion
        }
    }
}

