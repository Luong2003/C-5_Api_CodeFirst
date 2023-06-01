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
            builder.Property(x => x.DonGia).HasColumnType("float").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
            builder.Property(p => p.Idbill).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(p => p.IdproductDetails).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(p => p.Bill).WithMany(y => y.BillDetails).HasForeignKey(p => p.Idbill);
            builder.HasOne(p => p.ProductDetail).WithMany(y => y.BillDetails).HasForeignKey(p => p.IdproductDetails);
        }
    }
}
