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
            builder.Property(x => x.DonGia).HasColumnType("float").IsRequired();
            builder.Property(x => x.NgayTao).HasColumnType("Datetime").IsRequired();
            builder.Property(p => p.IdcartDetails).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(p => p.IdkhachHang).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(p => p.CartDetail).WithMany(y => y.Carts).HasForeignKey(p => p.IdcartDetails);
            builder.HasOne(p => p.KhachHang).WithMany(y => y.Carts).HasForeignKey(p => p.IdkhachHang);
        }
    }
}
