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
            builder.Property(x => x.BaoHanh).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.Series).HasColumnType("int").IsRequired();
            builder.Property(x => x.DoPhanGiai).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.SoLuongTon).HasColumnType("int").IsRequired();
            builder.Property(x => x.GiaBan).HasColumnType("float").IsRequired();
            builder.Property(x => x.GiaSale).HasColumnType("float").IsRequired();
            builder.Property(x => x.NhaSanXuat).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.TheLoai).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.NgaySanXuat).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.TrangThaiKhuyenMai).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(p => p.Idcolor).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(p => p.Idproduct).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(p => p.Idsize).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(p => p.IdSale).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(p => p.Color).WithMany(y => y.ProductDetails).HasForeignKey(p => p.Idcolor);
            builder.HasOne(p => p.Product).WithMany(y => y.ProductDetails).HasForeignKey(p => p.Idproduct);
            builder.HasOne(p => p.Size).WithMany(y => y.ProductDetails).HasForeignKey(p => p.Idsize);
            builder.HasOne(p => p.Sale).WithMany(y => y.ProductDetails).HasForeignKey(p => p.IdSale);
        }
    }
}
