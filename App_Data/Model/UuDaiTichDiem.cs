using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class UuDaiTichDiem
    {
        public Guid Id { get; set; }
        public Guid? IdchiTietTichDiem { get; set; }
        public Guid? IdtichDiem { get; set; }
        public Guid? Idbill { get; set; }
        public int? SoDiemDung { get; set; }
        public DateTime? NgayTichDiem { get; set; }
        public int? TrangThai { get; set; }

        public virtual ChiTietTichDiem? ChiTietTichDiem { get; set; }
        public virtual TichDiem? TichDiem { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
