using System;
using System.Collections.Generic;

namespace DesignFirstMVC.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Issue = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }

        public virtual ICollection<Issue> Issue { get; set; }
    }
}
