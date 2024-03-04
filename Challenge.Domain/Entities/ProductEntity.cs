using System;
using System.ComponentModel.DataAnnotations;


namespace Challenge.Domain.Entities
{
	public sealed class ProductEntity
	{
		[Key]
		public int ProductId { get; private set; }

		[Required]
		public string Description { get; private set; }

		[Required]
		public bool IsActive { get; private set; }

		[Required]
		public DateTime ManufactureDate { get; private set; }

		[Required]
		public DateTime ExpiryDate { get; private set; }

		[Required]
		public string SupplierCode { get; private set; }

		[Required]
		public string SupplierDescription { get; private set; }

		[Required]
		public string SupplierCNPJ { get; private set; }

		public ProductEntity(int id, string description, bool isActive, DateTime manufactureDate, DateTime expiryDate, string supplierCode, string supplierDescription, string supplierCNPJ)
		{
			ProductId = id;
			Description = description;
			IsActive = isActive;
			ManufactureDate = manufactureDate;
			ExpiryDate = expiryDate;
			SupplierCode = supplierCode;
			SupplierDescription = supplierDescription;
			SupplierCNPJ = supplierCNPJ;
		}
		public ProductEntity(string description, bool isActive, DateTime manufactureDate, DateTime expiryDate, string supplierCode, string supplierDescription, string supplierCNPJ)
		{

			Description = description;
			IsActive = isActive;
			ManufactureDate = manufactureDate;
			ExpiryDate = expiryDate;
			SupplierCode = supplierCode;
			SupplierDescription = supplierDescription;
			SupplierCNPJ = supplierCNPJ;
		}

		public void SetDescription(string description)
		{
			if (!string.IsNullOrEmpty(description))
			{
				Description = description;
			}
		}

		public void SetIsActive(bool? isActive)
		{
			IsActive = isActive ?? IsActive;
		}

		public void SetManufactureDate(DateTime? manufactureDate)
		{
			ManufactureDate = manufactureDate ?? ManufactureDate;
		}

		public void SetExpiryDate(DateTime? expiryDate)
		{
			ExpiryDate = expiryDate ?? ExpiryDate;
		}
		public void SetSupplierCode(string supplierCode)
		{
			SupplierCode = supplierCode != null ? supplierCode : SupplierCode;
		}

		public void SetSupplierDescription(string supplierDescription)
		{
			SupplierDescription = supplierDescription != null ? supplierDescription : SupplierDescription;
		}

		public void SetSupplierCNPJ(string supplierCNPJ)
		{
			SupplierCNPJ = supplierCNPJ != null ? SupplierCNPJ : SupplierCNPJ;
		}
	}
}
