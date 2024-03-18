using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductDetails = new HashSet<ProductDetail>();
            ShopCarts = new HashSet<ShopCart>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public decimal? ProductWeigt { get; set; }
        public bool IsActive { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
        public virtual ICollection<ShopCart> ShopCarts { get; set; }
    }
}
