using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class KhachHang
    {
        public Guid Id { get; set; }
        public Guid? IdtichDiem { get; set; }
        public string? Ten { get; set; }
        public string? Sdt { get; set; }
        public string? MatKhau { get; set; }
        public string? DiaChi { get; set; }

        public virtual TichDiem? TichDiem { get; set; }
        public virtual IEnumerable<Bill> Bills { get; set; }
        public virtual IEnumerable<Cart> Carts { get; set; }
    }
}
