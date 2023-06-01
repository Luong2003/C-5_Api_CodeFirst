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
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.ToTable("Sản Phẩm Chi Tiết");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CongNgheManHinh).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.BaoHanh).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.Series).HasColumnType("int").IsRequired();
            builder.Property(x => x.DoPhanGiai).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.SoLuongTon).HasColumnType("int").IsRequired();
            builder.Property(x => x.GiaNhap).HasColumnType("double").IsRequired();
            builder.Property(x => x.GiaBan).HasColumnType("double").IsRequired();
            builder.Property(x => x.NhaSanXuat).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.TheLoai).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.NgaySanXuat).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.TrangThaiKhuyenMai).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Idcolor).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.Idproduct).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.Idsize).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(x => x.Color).WithMany(y => y.ProductDetails).HasForeignKey(x => x.Idcolor);
            builder.HasOne(x => x.Product).WithMany(y => y.ProductDetails).HasForeignKey(x => x.Idproduct);
            builder.HasOne(x => x.Size).WithMany(y => y.ProductDetails).HasForeignKey(x => x.Idsize);
        }
    }
}
