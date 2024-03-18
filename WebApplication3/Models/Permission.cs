using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Permission
    {
        public Permission()
        {
            PermissionRoles = new HashSet<PermissionRole>();
        }

        public int PermissionId { get; set; }
        public bool Get { get; set; }
        public bool Post { get; set; }
        public bool Put { get; set; }
        public bool Del { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
