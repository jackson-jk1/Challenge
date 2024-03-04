using Challenge.Api.Request.DTOs;
using Challenge.Application.Interfaces;
using Challenge.Domain.Entities;
using Challenge.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

 namespace Challenge.Application.Services
	{
		public class ProductService : IProductService
		{
			private readonly IBaseRepository<ProductEntity> _repository;
			
			public ProductService(IBaseRepository<ProductEntity> repository)
			{
				_repository = repository;
			}

			public void Insert(ProductInsertDTO request)
			{
	
				ProductEntity entity = new (request.Description,
											 true,
											 request.ManufactureDate.Value,
											 request.ExpiryDate.Value,
											 request.SupplierCode,
											 request.Description,
											 request.SupplierCNPJ );
				_repository.Add(entity);
			}

			public void Update(ProductDTO request)
			{
				
				var entity = _repository.Select(request.ProductId.Value);
				entity.SetDescription(request.Description);
				entity.SetIsActive(request.IsActive);
				entity.SetManufactureDate(request.ManufactureDate);
				entity.SetExpiryDate(request.ExpiryDate);
				entity.SetSupplierCode(request.SupplierCode);
				entity.SetSupplierDescription(request.SupplierDescription);
				entity.SetSupplierCNPJ(request.SupplierCNPJ);
				_repository.Update(entity);
			}

			public void Delete(int id)
			{
				var entity = _repository.Select(id);
				entity.SetIsActive(false);
				_repository.Remove(entity);
			}

			public ProductEntity Select(int id)
			{
				return _repository.Select(id);
			}

			public IEnumerable<ProductEntity> Select()
			{
				return _repository.Select();
			}

			public IEnumerable<ProductEntity> Select(ProductFilterDTO request)
			{

			Expression<Func<ProductEntity, bool>> predicate = p =>
			(request.Description == null || p.Description.Contains(request.Description)) &&
			(request.IsActive == null || p.IsActive == request.IsActive) &&
			(request.ManufactureDateStart == null || p.ManufactureDate >= request.ManufactureDateStart) &&
			(request.ManufactureDateEnd == null || p.ManufactureDate <= request.ManufactureDateEnd) &&
			(request.ExpiryDateStart == null || p.ExpiryDate >= request.ExpiryDateStart) &&
			(request.ExpiryDateEnd == null || p.ExpiryDate <= request.ExpiryDateEnd) &&
			(request.SupplierCNPJ == null || p.SupplierCNPJ == request.SupplierCNPJ);
			return _repository.Select(predicate);
			}
		}
	}
