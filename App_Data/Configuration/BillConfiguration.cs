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
            builder.Property(x => x.TienShip).HasColumnType("double").IsRequired();
            builder.Property(x => x.FreeShip).HasColumnType("double").IsRequired();
            builder.Property(x => x.TongTien).HasColumnType("double").IsRequired();
            builder.Property(x => x.SoTienGiam).HasColumnType("double").IsRequired();
            builder.Property(x => x.TienKhachDua).HasColumnType("double").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
            builder.Property(x => x.IdkhachHang).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.Idvoucher).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.IdnhanVien).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.IduuDaiTichDiem).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(x => x.KhachHang).WithMany(y => y.Bills).HasForeignKey(x => x.IdkhachHang);
            builder.HasOne(x => x.UuDaiTichDiem).WithMany(y => y.Bills).HasForeignKey(x => x.IduuDaiTichDiem);
            builder.HasOne(x => x.NhanVien).WithMany(y => y.Bills).HasForeignKey(x => x.IdnhanVien);
            builder.HasOne(x => x.Voucher).WithMany(y => y.Bills).HasForeignKey(x => x.Idvoucher);
        }
    }
}
