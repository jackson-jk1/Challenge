using Newtonsoft.Json;
using System;

namespace Challenge.Api.Request.DTOs
{
	public sealed class ProductInsertDTO
	{

		public string Description { get; set; }
		public bool? IsActive { get; set; }
		public DateTime? ManufactureDate { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public string SupplierCode { get; set; }
		public string SupplierDescription { get; set; }
		public string SupplierCNPJ { get; set; }
	}
}
