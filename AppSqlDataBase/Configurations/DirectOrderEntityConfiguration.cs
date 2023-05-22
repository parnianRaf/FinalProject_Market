using System;
using AppCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSqlDataBase.Configurations
{
	public class DirectOrderEntityConfiguration:IEntityTypeConfiguration<DirectOrder>
	{

        public void Configure(EntityTypeBuilder<DirectOrder> entity)
        {
            #region Property
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedNever();

            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)");
            #endregion

            #region Relational Property
            #endregion

            #region Seed Data
            #endregion
        }
    }
}

