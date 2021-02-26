using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHelper.Models
{
    public enum Role
    {
        ProjectManager, Dev, Tester, QA, AutomationTester
    }

    public class ProjectMember
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string MemberId { get; set; }
        public Role? Role { get; set; }
        public virtual Project Project { get; set; }
        public virtual ApplicationUser Member { get; set; }
    }
}
