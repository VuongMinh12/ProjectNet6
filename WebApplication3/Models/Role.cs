using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Role
    {
        public Role()
        {
            PermissionRoles = new HashSet<PermissionRole>();
            UserRoles = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
