using System;
using System.Collections.Generic;

#nullable disable

namespace LMS.WebAPI.Models
{
    public partial class Project
    {
        public Project()
        {
            Expenses = new HashSet<Expense>();
            Fees = new HashSet<Fee>();
            Tasks = new HashSet<Task>();
            Times = new HashSet<Time>();
        }

        public int Id { get; set; }
        public string Reference { get; set; }
        public int TypeProjectId { get; set; }
        public int YearOfProject { get; set; }
        public int? IdForYear { get; set; }
        public int? PartnerId { get; set; }
        public int? LeadingLawyerId { get; set; }
        public int ClientId { get; set; }
        public string Description { get; set; }
        public int? TypeProjectStatusId { get; set; }
        public decimal Rate { get; set; }
        public decimal VatRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee LeadingLawyer { get; set; }
        public virtual Employee Partner { get; set; }
        public virtual TypeProject TypeProject { get; set; }
        public virtual TypeProjectStatus TypeProjectStatus { get; set; }
        public virtual VatRate VatRateNavigation { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Time> Times { get; set; }
    }
}
