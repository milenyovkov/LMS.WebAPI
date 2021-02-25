﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LMS.WebAPI.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int? Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? AllDay { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public int? Label { get; set; }
        public int? ResourceId { get; set; }
        public string ResourceIds { get; set; }
        public string ReminderInfo { get; set; }
        public string RecurrenceInfo { get; set; }
        public string CustomField1 { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
