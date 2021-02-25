using System;
using System.Collections.Generic;

#nullable disable

namespace LMS.WebAPI.Models
{
    public partial class VatRate
    {
        public VatRate()
        {
            Projects = new HashSet<Project>();
        }

        public decimal Rate { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
