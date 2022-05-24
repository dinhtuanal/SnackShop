using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> entity)
        {
            entity.HasKey(e=>e.FoodId);
            entity.Property(e => e.FoodId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e=>e.Description).HasMaxLength(500);
            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.HasOne(s => s.SubCategory)
                .WithMany(f => f.Foods)
                .HasForeignKey(s => s.SubCategoryId)
                .HasConstraintName("FK_Foods_SubCategories");
        }
    }
}
