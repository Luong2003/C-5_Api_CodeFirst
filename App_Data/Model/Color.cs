using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class Color
    {
        public Guid Id { get; set; }
        public string? Ma { get; set; }
        public string? Ten { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
