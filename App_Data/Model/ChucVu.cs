using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class ChucVu
    {
        public Guid Id { get; set; }
        public string? MaChucVu { get; set; }
        public string? TenChucVu { get; set; }

        public virtual IEnumerable<NhanVien> NhanViens { get; set; }
    }
}
