using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class NhanVien
    {
        public Guid Id { get; set; }
        public Guid? IdchucVu { get; set; }
        public string? Ma { get; set; }
        public string? HoTen { get; set; }
        public string? Sdt { get; set; }
        public string? MatKhau { get; set; }
        public string? DiaChi { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? Ngaysinh { get; set; }

        public virtual ChucVu? ChucVu { get; set; }
        public virtual IEnumerable<Bill> Bills { get; set; }
    }
}
