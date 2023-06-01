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
    public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.ToTable("Nhân viên");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ma).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.HoTen).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Sdt).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.MatKhau).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.DiaChi).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.GioiTinh).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Ngaysinh).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.IdchucVu).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(x => x.ChucVu).WithMany(y => y.NhanViens).HasForeignKey(x => x.IdchucVu);
        }
    }
}
