using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class ChiTietTichDiem
    {
        public Guid Id { get; set; }
        public int? SoDiemTich { get; set; }
        public int? TrangThai { get; set; }

        public virtual IEnumerable<UuDaiTichDiem> UuDaiTichDiems { get; set; }
    }
}
