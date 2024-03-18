using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class User
    {
        public User()
        {
            ShopCarts = new HashSet<ShopCart>();
            UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<ShopCart> ShopCarts { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
