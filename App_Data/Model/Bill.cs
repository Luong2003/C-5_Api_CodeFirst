using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class Bill
    {
        public Guid Id { get; set; }
        public Guid? IdkhachHang { get; set; }
        public Guid? IduuDaiTichDiem { get; set; }
        public Guid? IdnhanVien { get; set; }
        public Guid? Idvoucher { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public string? GiamGia { get; set; }
        public string? MoTa { get; set; }
        public string? DiaChiShop { get; set; }
        public string? DiaChiKhachHang { get; set; }
        public double? TienShip { get; set; }
        public double? FreeShip { get; set; }
        public double? TongTien { get; set; }
        public double? SoTienGiam { get; set; }
        public double? TienKhachDua { get; set; }
        public int? TrangThai { get; set; }

        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
        public virtual UuDaiTichDiem? UuDaiTichDiem { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
