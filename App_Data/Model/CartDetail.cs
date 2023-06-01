using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class CartDetail
    {
        public Guid Id { get; set; }
        public Guid? IdproductDetails { get; set; }
        public float? DonGia { get; set; }
        public int? SoLuong { get; set; }

        public virtual ProductDetail? ProductDetail { get; set; }
        public virtual IEnumerable<Cart> Carts { get; set; }
    }
}
