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
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> entity)
        {
            entity.HasKey(s=>s.SubCategoryId);
            entity.Property(s => s.SubCategoryId).HasDefaultValueSql("(newid())");
            entity.Property(s => s.SubCategoryName).HasMaxLength(255);
            entity.Property(s=>s.Description).HasMaxLength(500);
            entity.Property(s => s.DateCreated).HasColumnType("datetime");

            entity.HasOne(c => c.Category)
                .WithMany(s => s.SubCategories)
                .HasForeignKey(c => c.CategoryId)
                .HasConstraintName("FK_SubCategories_Categories");
        }
    }
}
