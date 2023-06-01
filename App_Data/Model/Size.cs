using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class Size
    {
        public Guid Id { get; set; }
        public string? Ma { get; set; }
        public string? Size1 { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
