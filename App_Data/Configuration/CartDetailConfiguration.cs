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
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.ToTable("Giỏ hàng chi tiết");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SoLuong).HasColumnType("int").IsRequired();
            builder.Property(x => x.DonGia).HasColumnType("double").IsRequired();
            builder.Property(x => x.IdproductDetails).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(x => x.ProductDetail).WithMany(y => y.CartDetails).HasForeignKey(x => x.IdproductDetails);
        }
    }
}
