using System;
using System.Collections.Generic;

namespace LMS.WebAPI.Models
{
    public partial class LawyersView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public int PositionId { get; set; }
        public string AspNetUserId { get; set; }
    }
}
