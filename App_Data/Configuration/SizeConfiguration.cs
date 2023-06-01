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
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Kích Cỡ");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ma).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Size1).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
