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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(e=> e.CategoryId);
            entity.Property(e => e.CategoryId).HasDefaultValueSql("(newid())");
            entity.Property(e=>e.CategoryName).HasMaxLength(255);
            entity.Property(e => e.Description).HasColumnType("ntext");
        }
    }
}
