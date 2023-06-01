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
    public class UuDaiTichDiemConfiguration : IEntityTypeConfiguration<UuDaiTichDiem>
    {
        public void Configure(EntityTypeBuilder<UuDaiTichDiem> builder)
        {
            builder.ToTable("Ưu đãi tích điểm");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SoDiemDung).HasColumnType("int").IsRequired();
            builder.Property(x => x.NgayTichDiem).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
            builder.Property(x => x.IdchiTietTichDiem).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.IdtichDiem).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(x => x.ChiTietTichDiem).WithMany(y => y.UuDaiTichDiems).HasForeignKey(x => x.IdchiTietTichDiem);
            builder.HasOne(x => x.TichDiem).WithMany(y => y.UuDaiTichDiems).HasForeignKey(x => x.IdtichDiem);
        }
    }
}
