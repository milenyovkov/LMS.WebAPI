using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.WebAPI.Models
{
    public class FeesReportByEmployee
	{
		[Key]
		public string EmployeeName { get; set; }
		public decimal? TimeInHours { get; set; }
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
