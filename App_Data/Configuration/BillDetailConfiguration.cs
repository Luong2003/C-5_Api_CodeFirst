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
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.ToTable("Hóa Đơn Chi Tiết");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SoLuong).HasColumnType("int").IsRequired();
            builder.Property(x => x.DonGia).HasColumnType("double").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
            builder.Property(x => x.Idbill).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.IdproductDetails).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(x => x.Bill).WithMany(y => y.BillDetails).HasForeignKey(x => x.Idbill);
            builder.HasOne(x => x.ProductDetail).WithMany(y => y.BillDetails).HasForeignKey(x => x.IdproductDetails);
        }
    }
}
