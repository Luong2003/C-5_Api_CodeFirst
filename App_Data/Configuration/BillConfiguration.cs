using App_Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Configuration
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Hóa Đơn");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NgayThanhToan).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.GiamGia).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.DiaChiShop).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.DiaChiKhachHang).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.TienShip).HasColumnType("float").IsRequired();
            builder.Property(x => x.FreeShip).HasColumnType("float").IsRequired();
            builder.Property(x => x.TongTien).HasColumnType("float").IsRequired();
            builder.Property(x => x.SoTienGiam).HasColumnType("float").IsRequired();
            builder.Property(x => x.TienKhachDua).HasColumnType("float").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
            builder.Property(p => p.IdkhachHang).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(p => p.Idvoucher).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(p => p.IdnhanVien).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(p => p.IduuDaiTichDiem).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(p => p.KhachHang).WithMany(y => y.Bills).HasForeignKey(p => p.IdkhachHang);
            builder.HasOne(p => p.UuDaiTichDiem).WithMany(y => y.Bills).HasForeignKey(p => p.IduuDaiTichDiem);
            builder.HasOne(p => p.NhanVien).WithMany(y => y.Bills).HasForeignKey(p => p.IdnhanVien);
            builder.HasOne(p => p.Voucher).WithMany(y => y.Bills).HasForeignKey(p => p.Idvoucher);
        }
    }
}
