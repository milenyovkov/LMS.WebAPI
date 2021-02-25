using System;
using System.Collections.Generic;

#nullable disable

namespace LMS.WebAPI.Models
{
    public partial class Resource
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public int? Color { get; set; }
        public byte[] Image { get; set; }
        public string CustomField1 { get; set; }
    }
}
