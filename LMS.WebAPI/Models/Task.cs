using System;
using System.Collections.Generic;

#nullable disable

namespace LMS.WebAPI.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public int OwnerId { get; set; }
        public int AssignedId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int TaskStatusId { get; set; }
        public int TaskPriorityId { get; set; }
        public int? TaskCompletion { get; set; }
        public bool TaskReminder { get; set; }
        public DateTime? TaskReminderDate { get; set; }

        public virtual Employee Assigned { get; set; }
        public virtual Employee Owner { get; set; }
        public virtual Project Project { get; set; }
        public virtual TypeTaskPriority TaskPriority { get; set; }
        public virtual TypeTaskStatus TaskStatus { get; set; }
    }
}
