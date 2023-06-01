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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Giỏ hàng");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SoLuong).HasColumnType("int").IsRequired();
            builder.Property(x => x.DonGia).HasColumnType("double").IsRequired();
            builder.Property(x => x.NgayTao).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.IdcartDetails).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.IdkhachHang).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(x => x.CartDetail).WithMany(y => y.Carts).HasForeignKey(x => x.IdcartDetails);
            builder.HasOne(x => x.KhachHang).WithMany(y => y.Carts).HasForeignKey(x => x.IdkhachHang);
        }
    }
}
