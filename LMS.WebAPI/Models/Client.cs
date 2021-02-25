using System;
using System.Collections.Generic;

#nullable disable

namespace LMS.WebAPI.Models
{
    public partial class Client
    {
        public Client()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string ResponsibleName { get; set; }
        public string CountryId { get; set; }
        public string Address { get; set; }
        public string AddressCorrespondence { get; set; }
        public string CompanyCase { get; set; }
        public string IdNumber { get; set; }
        public string VatId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Notes { get; set; }
        public int? TypeClientId { get; set; }
        public int? PartnerId { get; set; }
        public int? LeadingLawyerId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Country Country { get; set; }
        public virtual Employee LeadingLawyer { get; set; }
        public virtual Employee Partner { get; set; }
        public virtual TypeClient TypeClient { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
