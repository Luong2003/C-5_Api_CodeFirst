using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class ProductDetail
    {
        public Guid Id { get; set; }
        public Guid? Idproduct { get; set; }
        public Guid? Idcolor { get; set; }
        public Guid? Idsize { get; set; }
        public string? CongNgheManHinh { get; set; }
        public DateTime? BaoHanh { get; set; }
        public int? Series { get; set; }
        public string? DoPhanGiai { get; set; }
        public string? MoTa { get; set; }
        public int? SoLuongTon { get; set; }
        public double? GiaNhap { get; set; }
        public double? GiaBan { get; set; }
        public string? NhaSanXuat { get; set; }
        public string? TheLoai { get; set; }
        public DateTime? NgaySanXuat { get; set; }
        public string? TrangThaiKhuyenMai { get; set; }

        public virtual Color? Color{ get; set; }
        public virtual Product? Product { get; set; }
        public virtual Size? Size{ get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
