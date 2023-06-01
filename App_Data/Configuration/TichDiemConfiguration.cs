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
    public class TichDiemConfiguration : IEntityTypeConfiguration<TichDiem>
    {
        public void Configure(EntityTypeBuilder<TichDiem> builder)
        {
            builder.ToTable("Tích điểm");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SoDiem).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
