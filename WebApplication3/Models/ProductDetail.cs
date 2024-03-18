using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class ProductDetail
    {
        public int ProductDetailId { get; set; }
        public int? ProductId { get; set; }
        public int? ColorId { get; set; }
        public decimal? Price { get; set; }
        public int? QuanlityId { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }

        public virtual Color? Color { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Quanlity? Quanlity { get; set; }
    }
}
