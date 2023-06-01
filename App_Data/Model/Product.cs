using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class Product
    {
        public Guid Id { get; set; }
        public string? MaSp { get; set; }
        public string? TenSp { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
