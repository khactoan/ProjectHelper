using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProjectHelper.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}