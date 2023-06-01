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
    public class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("Khách hàng");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ten).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Sdt).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.MatKhau).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.DiaChi).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.IdtichDiem).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(x => x.TichDiem).WithMany(y => y.KhachHangs).HasForeignKey(x => x.IdtichDiem);
        }
    }
}
