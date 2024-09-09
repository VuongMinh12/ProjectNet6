using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Brand
    {
        public int No { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }

    }
}
