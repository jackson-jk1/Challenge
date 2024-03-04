using Swashbuckle.AspNetCore.Annotations;
using System;


namespace Challenge.Api.Request.DTOs
{
	public sealed class ProductFilterDTO
	{

		public string Description { get; set; } = null;
		public bool? IsActive { get; set; }
		public DateTime? ManufactureDateStart { get; set; }
		public DateTime? ManufactureDateEnd { get; set; }
		public DateTime? ExpiryDateStart { get; set; }
		public DateTime? ExpiryDateEnd { get; set; }
		public string SupplierCNPJ { get; set; } = null;


	}
}
