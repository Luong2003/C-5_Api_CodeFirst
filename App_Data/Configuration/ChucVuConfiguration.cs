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
    public class ChucVuConfiguration : IEntityTypeConfiguration<ChucVu>
    {
        public void Configure(EntityTypeBuilder<ChucVu> builder)
        {
            builder.ToTable("Chức vụ");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MaChucVu).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.TenChucVu).HasColumnType("nvarchar(1000)").IsRequired();
            
        }
    }
}
