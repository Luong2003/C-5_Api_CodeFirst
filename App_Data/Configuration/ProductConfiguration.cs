using App_Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Sản Phẩm");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MaSp).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.TenSp).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
