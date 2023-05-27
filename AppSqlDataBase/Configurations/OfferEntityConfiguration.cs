using System;
using AppCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSqlDataBase.Configurations
{
	public class OfferEntityConfiguration:IEntityTypeConfiguration<Offer>
	{
        public void Configure(EntityTypeBuilder<Offer> entity)
        {
            #region Property
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedNever();

            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)");
            #endregion

            #region Relational Property
            entity.HasOne(d => d.Auction)
                .WithMany(p => p.Offers)
                .HasForeignKey(d => d.AuctionId);
            #endregion

            #region Seed Data
            #endregion
        }
    }
}

