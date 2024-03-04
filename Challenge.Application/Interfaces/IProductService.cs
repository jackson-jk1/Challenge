using Challenge.Api.Request.DTOs;
using Challenge.Domain.Entities;
using System.Collections.Generic;


namespace Challenge.Application.Interfaces
{
	public interface IProductService
	{
		void Insert(ProductInsertDTO request);
		void Update(ProductDTO request);
		void Delete(int id);
		ProductEntity Select(int id);
		IEnumerable<ProductEntity> Select();
		IEnumerable<ProductEntity> Select(ProductFilterDTO request);
	}
}
