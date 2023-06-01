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
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable("Mã giảm giá");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ma).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Ten).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.PhanTramGiam).HasColumnType("int").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
        }
    }
}
