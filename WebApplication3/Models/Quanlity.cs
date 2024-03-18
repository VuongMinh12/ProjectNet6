using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Quanlity
    {
        public Quanlity()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int QuanlityId { get; set; }
        public string? QuanlityName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
