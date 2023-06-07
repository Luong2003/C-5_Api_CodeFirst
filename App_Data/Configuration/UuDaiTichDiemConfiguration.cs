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
            builder.Property(p => p.IdtichDiem).HasColumnType("UNIQUEIDENTIFIER");
            builder.HasOne(p => p.TichDiem).WithMany(y => y.UuDaiTichDiems).HasForeignKey(p => p.IdtichDiem);
        }
    }
}
