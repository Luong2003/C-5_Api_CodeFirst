using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class BillDetail
    {
        public Guid Id { get; set; }
        public Guid? IdproductDetails { get; set; }
        public Guid? Idbill { get; set; }
        public int? SoLuong { get; set; }
        public double? DonGia { get; set; }
        public int? TrangThai { get; set; }

        public virtual Bill? Bill { get; set; }
        public virtual ProductDetail? ProductDetail { get; set; }
    }
}
