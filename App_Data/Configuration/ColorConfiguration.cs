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
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Màu Sắc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ma).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Ten).HasColumnType("nvarchar(1000)").IsRequired();        }
    }
}
