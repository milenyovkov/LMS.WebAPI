using System;
using System.Collections.Generic;

#nullable disable

namespace LMS.WebAPI.Models
{
    public partial class TypeProjectStatus
    {
        public TypeProjectStatus()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
