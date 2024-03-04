

using Challenge.Api.Request.DTOs;
using Challenge.Application.Services;
using Challenge.Domain.Entities;
using Challenge.Domain.Interfaces.Base;
using System.Collections.Generic;
using System;
using System.Linq;
using Xunit;
using Moq;

namespace Challenge.Tests.Aplication
{
	public sealed class ProductServiceTest
	{
		private readonly ProductEntity _entity;

		public ProductServiceTest()
		{
			_entity = new ProductEntity(1,
									  "ProductEntity 1",
									  true,
									  DateTime.Now,
									  DateTime.Now.AddYears(1),
									  "1",
									  "Supplier 1",
									  "12.345.678/0001-90");
		}
		[Fact]
		public void Insert_ProductInsertedSuccessfully()
		{
			// Arrange
			var repositoryMock = new Mock<IBaseRepository<ProductEntity>>();
			var productService = new ProductService(repositoryMock.Object);
			var request = new ProductInsertDTO
			{
				Description = "Test Product",
				ManufactureDate = DateTime.Now,
				ExpiryDate = DateTime.Now.AddDays(30),
				SupplierCode = "12345",
				SupplierDescription = "Test Supplier",
				SupplierCNPJ = "12345678901234"
			};
			productService.Insert(request);

			repositoryMock.Verify(repo => repo.Add(It.IsAny<ProductEntity>()), Times.Once);
		}

		[Fact]
		public void Update_ProductUpdatedSuccessfully()
		{
			// Arrange
			var repositoryMock = new Mock<IBaseRepository<ProductEntity>>();
			var productService = new ProductService(repositoryMock.Object);
			var productId = 1;
			var request = new ProductDTO
			{
				ProductId = productId,
				Description = "Updated Product",
				IsActive = true,
				ManufactureDate = DateTime.Now,
				ExpiryDate = DateTime.Now.AddDays(30),
				SupplierCode = "12345",
				SupplierDescription = "Test Supplier",
				SupplierCNPJ = "12345678901234"
			};
			repositoryMock.Setup(repo => repo.Select(productId)).Returns(_entity);

			// Act
			productService.Update(request);

			// Assert
			repositoryMock.Verify(repo => repo.Update(It.IsAny<ProductEntity>()), Times.Once);
		}

		[Fact]
		public void Delete_ProductMarkedAsInactive()
		{
			// Arrange
			var repositoryMock = new Mock<IBaseRepository<ProductEntity>>();
			var productService = new ProductService(repositoryMock.Object);
			var productId = 1;
			repositoryMock.Setup(repo => repo.Select(productId)).Returns(_entity);

			// Act
			productService.Delete(productId);

			// Assert
			repositoryMock.Verify(repo => repo.Remove(It.IsAny<ProductEntity>()), Times.Once);
		}

		[Fact]
		public void SelectById_ReturnsCorrectProduct()
		{
			// Arrange
			var repositoryMock = new Mock<IBaseRepository<ProductEntity>>();
			var productService = new ProductService(repositoryMock.Object);
			var productId = 1;
			
			repositoryMock.Setup(repo => repo.Select(productId)).Returns(_entity);

			// Act
			var result = productService.Select(productId);

			// Assert
			Assert.Equal(_entity, result);
		}

		[Fact]
		public void SelectAll_ReturnsAllProducts()
		{
			// Arrange
			var repositoryMock = new Mock<IBaseRepository<ProductEntity>>();
			var productService = new ProductService(repositoryMock.Object);
			var expectedProducts = new List<ProductEntity>
			{
				_entity
			};
			repositoryMock.Setup(repo => repo.Select()).Returns((IQueryable<ProductEntity>)expectedProducts);
			var result = productService.Select();

			Assert.Equal(expectedProducts, result);
		}
	}
}
