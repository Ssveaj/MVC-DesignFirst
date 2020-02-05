using System;
using System.Collections.Generic;

namespace DesignFirstMVC.Models
{
    public partial class Issue
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual IssueStatus Status { get; set; }
    }
}
