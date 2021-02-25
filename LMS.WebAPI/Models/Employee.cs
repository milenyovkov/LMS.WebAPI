using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace LMS.WebAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Appointments = new HashSet<Appointment>();
            ClientLeadingLawyers = new HashSet<Client>();
            ClientPartners = new HashSet<Client>();
            Expenses = new HashSet<Expense>();
            Fees = new HashSet<Fee>();
            ProjectLeadingLawyers = new HashSet<Project>();
            ProjectPartners = new HashSet<Project>();
            TaskAssigneds = new HashSet<Task>();
            TaskOwners = new HashSet<Task>();
            Times = new HashSet<Time>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public int PositionId { get; set; }
        public string AspNetUserId { get; set; }
        public string AspNetRoleId { get; set; }

        public virtual IdentityUser AspNetRole { get; set; }
        public virtual IdentityRole AspNetUser { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Client> ClientLeadingLawyers { get; set; }
        public virtual ICollection<Client> ClientPartners { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<Project> ProjectLeadingLawyers { get; set; }
        public virtual ICollection<Project> ProjectPartners { get; set; }
        public virtual ICollection<Task> TaskAssigneds { get; set; }
        public virtual ICollection<Task> TaskOwners { get; set; }
        public virtual ICollection<Time> Times { get; set; }
    }
}
