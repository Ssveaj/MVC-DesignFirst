using System;
using System.Collections.Generic;

namespace DesignFirstMVC.Models
{
    public partial class IssueStatus
    {
        public IssueStatus()
        {
            Issue = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Issue> Issue { get; set; }
    }
}
