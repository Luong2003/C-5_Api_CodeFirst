using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class Cart
    {
        public Guid Id { get; set; }
        public Guid? IdkhachHang { get; set; }
        public Guid? IdcartDetails { get; set; }
        public int? SoLuong { get; set; }
        public double? DonGia { get; set; }
        public DateTime? NgayTao { get; set; }

        public virtual CartDetail? CartDetail { get; set; }
        public virtual KhachHang? KhachHang { get; set; }
    }
}
