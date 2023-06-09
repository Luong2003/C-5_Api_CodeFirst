using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ViewModel
{
    public class ProductDetailViewModel
    {
        public Guid Id { get; set; }
        public string? TenSp { get; set; }
        public string? Color { get; set; }
        public int? Size { get; set; }
        public int? GiaTriSale { get; set; }
        public string? CongNgheManHinh { get; set; }
        public DateTime? BaoHanh { get; set; }
        public int? Series { get; set; }
        public string? DoPhanGiai { get; set; }
        public string? MoTa { get; set; }
        public int? SoLuongTon { get; set; }
        public float? GiaBan { get; set; }
        public float? GiaSale { get; set; }
        public string? NhaSanXuat { get; set; }
        public string? TheLoai { get; set; }
        public DateTime? NgaySanXuat { get; set; }
        public string? TrangThaiKhuyenMai { get; set; }
    }
}
