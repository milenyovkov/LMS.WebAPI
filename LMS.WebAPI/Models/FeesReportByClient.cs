using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.WebAPI.Models
{
    public class FeesReportByClient
    {
		[Key]
		public string ClientName { get; set; }
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
