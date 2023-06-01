﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Model
{
    public partial class Voucher
    {
        public Guid Id { get; set; }
        public string? Ma { get; set; }
        public string? Ten { get; set; }
        public int? PhanTramGiam { get; set; }
        public int? TrangThai { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
