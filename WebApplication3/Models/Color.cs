﻿using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Color
    {
        public Color()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int ColorId { get; set; }
        public string ColorName { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
