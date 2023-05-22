using System;
using AppCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSqlDataBase.Configurations
{
	public class PavilionEntityConfiguration:IEntityTypeConfiguration<Pavilion>
	{
	
        public void Configure(EntityTypeBuilder<Pavilion> entity)
        {
            #region Property
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedNever();

            entity.Property(e => e.Title)
                .HasMaxLength(50);
            #endregion

            #region Relational Property
            entity.HasOne(d => d.Seller).
                WithMany(p => p.Pavilions)
                .HasForeignKey(d => d.SellerId);
            #endregion

            #region Seed Data
            #endregion

        }
    }
}

