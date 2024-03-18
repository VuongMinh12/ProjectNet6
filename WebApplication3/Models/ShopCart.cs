using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class ShopCart
    {
        public int ShopCartId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
