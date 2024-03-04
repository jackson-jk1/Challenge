using Challenge.Domain.Entities;
using System;
using Xunit;

namespace Challenge.Test.Domain
{
	
	public sealed class ProductEntityTest
	{
		
			[Fact]
			public void Constructor_WithValidArguments_ShouldInitializeProperties()
			{
		
				int id = 1;
				string description = "Product description";
				bool isActive = true;
				DateTime manufactureDate = DateTime.Now;
				DateTime expiryDate = DateTime.Now.AddDays(30);
				string supplierCode = "123";
				string supplierDescription = "Supplier description";
				string supplierCNPJ = "12345678901234";

				var product = new ProductEntity(id, description, isActive, manufactureDate, expiryDate, supplierCode, supplierDescription, supplierCNPJ);

				Assert.Equal(id, product.ProductId);
				Assert.Equal(description, product.Description);
				Assert.Equal(isActive, product.IsActive);
				Assert.Equal(manufactureDate, product.ManufactureDate);
				Assert.Equal(expiryDate, product.ExpiryDate);
				Assert.Equal(supplierCode, product.SupplierCode);
				Assert.Equal(supplierDescription, product.SupplierDescription);
				Assert.Equal(supplierCNPJ, product.SupplierCNPJ);
			}

			[Fact]
			public void SetDescription_WithValidDescription_ShouldUpdateDescription()
			{
			
				var product = new ProductEntity("Initial description", true, DateTime.Now, DateTime.Now.AddDays(30), "123", "Initial supplier description", "12345678901234");
				product.SetDescription("New description");

				Assert.Equal("New description", product.Description);
			}

			[Fact]
			public void SetIsActive_WithNull_ShouldNotChangeIsActive()
			{
				
				var product = new ProductEntity("Description", true, DateTime.Now, DateTime.Now.AddDays(30), "123", "Supplier description", "12345678901234");
				product.SetIsActive(null);

				Assert.True(product.IsActive);
			}

			[Fact]
			public void SetManufactureDate_WithNull_ShouldNotChangeManufactureDate()
			{
				
				var currentDate = DateTime.Now;
				var product = new ProductEntity("Description", true, currentDate, currentDate.AddDays(30), "123", "Supplier description", "12345678901234");
				product.SetManufactureDate(null);

				Assert.Equal(currentDate, product.ManufactureDate);
			}

			[Fact]
			public void SetExpiryDate_WithNull_ShouldNotChangeExpiryDate()
			{
		
				var currentDate = DateTime.Now;
				var product = new ProductEntity("Description", true, currentDate, currentDate.AddDays(30), "123", "Supplier description", "12345678901234");
				product.SetExpiryDate(null);

				Assert.Equal(currentDate.AddDays(30), product.ExpiryDate);
			}

			[Fact]
			public void SetSupplierCode_WithNull_ShouldNotChangeSupplierCode()
			{
			
				var product = new ProductEntity("Description", true, DateTime.Now, DateTime.Now.AddDays(30), "123", "Supplier description", "12345678901234");
				product.SetSupplierCode(null);

				Assert.Equal("123", product.SupplierCode);
			}

			[Fact]
			public void SetSupplierDescription_WithNull_ShouldNotChangeSupplierDescription()
			{
			
				var product = new ProductEntity("Description", true, DateTime.Now, DateTime.Now.AddDays(30), "123", "Supplier description", "12345678901234");
				product.SetSupplierDescription(null);

				Assert.Equal("Supplier description", product.SupplierDescription);
			}

			[Fact]
			public void SetSupplierCNPJ_WithNull_ShouldNotChangeSupplierCNPJ()
			{
				
				var product = new ProductEntity("Description", true, DateTime.Now, DateTime.Now.AddDays(30), "123", "Supplier description", "12345678901234");
				product.SetSupplierCNPJ(null);

				Assert.Equal("12345678901234", product.SupplierCNPJ);
			}

			[Fact]
			public void SetManufactureDate_WithNewDate_ShouldUpdateManufactureDate()
			{
				
				var currentDate = DateTime.Now;
				var newDate = currentDate.AddDays(10);
				var product = new ProductEntity("Description", true, currentDate, currentDate.AddDays(30), "123", "Supplier description", "12345678901234");		
				product.SetManufactureDate(newDate);

				Assert.Equal(newDate, product.ManufactureDate);
			}

			[Fact]
			public void SetExpiryDate_WithNewDate_ShouldUpdateExpiryDate()
			{
				var currentDate = DateTime.Now;
				var newDate = currentDate.AddDays(40);
				var product = new ProductEntity("Description", true, currentDate, currentDate.AddDays(30), "123", "Supplier description", "12345678901234");			
				product.SetExpiryDate(newDate);

				Assert.Equal(newDate, product.ExpiryDate);
			}
	}
}
