using System;
using System.Collections.Generic;

#nullable disable

namespace LMS.WebAPI.Models
{
    public partial class TypeProject
    {
        public TypeProject()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
