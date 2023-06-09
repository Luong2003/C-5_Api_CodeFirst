﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public class Sale
    {
        public Guid IDSale { get; set; }
        public string MaSale { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int GiaTriSale { get; set; }
        public int TrangThai { get; set; }

        public virtual IEnumerable<ProductDetail> ProductDetails { get; set; }
    }
}
