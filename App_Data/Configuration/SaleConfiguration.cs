using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App_Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Configuration
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Giảm Giá sản phẩm");
            builder.HasKey(x => x.IDSale);
            builder.Property(x => x.MaSale).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.NgayBatDau).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.NgayKetThuc).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.GiaTriSale).HasColumnType("int").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
        }
    }
}

