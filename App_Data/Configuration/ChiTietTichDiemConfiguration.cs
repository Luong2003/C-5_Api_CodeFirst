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
    public class ChiTietTichDiemConfiguration : IEntityTypeConfiguration<ChiTietTichDiem>
    {
        public void Configure(EntityTypeBuilder<ChiTietTichDiem> builder)
        {
            builder.ToTable("Chi Tiết tích điểm");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SoDiemTich).HasColumnType("int").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
        }
    }
}
