using System;
using AppCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSqlDataBase.Configurations
{
	public class CategoryEntityConfiguration:IEntityTypeConfiguration<Category>
	{
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            #region Property
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedNever();

            entity.Property(e => e.Title)
                .HasMaxLength(50);
            #endregion

            #region Relational Property
            #endregion

            #region Seed Data
            #endregion
        }
    }
}

