using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.WebAPI.Models
{
    public class ClientsReport
    {
		public string TypeData { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
		[Key]
		public int Id { get; set; }
		public int Year { get; set; }
		public int Month { get; set; }
		[DataType(DataType.Date)] 
		public DateTime Date { get; set; }
		public int ProjectId { get; set; }
		public string ProjectReference { get; set; }
		public int EmployeeId { get; set; }
		public string EmployeeName { get; set; }
		public int? Hours { get; set; }
		public int? Minutes { get; set; }
		public int? TimeInMinutes { get; set; }
		[Column(TypeName = "decimal(15, 2)")]
		public decimal? TimeInHours { get; set; }
		public string Description { get; set; }
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(15, 2)")]
		public decimal Rate { get; set; }
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(15, 2)")]
		public decimal VatRate { get; set; }
		public bool? Paid { get; set; }
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(15, 2)")]
		public decimal Amount { get; set; }
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(15, 2)")]
		public decimal Vat { get; set; }
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(15, 2)")]
		public decimal Total { get; set; }
	}
}
