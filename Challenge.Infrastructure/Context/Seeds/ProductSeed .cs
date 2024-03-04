using Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Challenge.Infrastructure.Context.Seeds
{
	internal sealed class ProductSeed : IEntityTypeConfiguration<ProductEntity>
	{
		public void Configure(EntityTypeBuilder<ProductEntity> builder)
		{
			builder.HasData(
			   new ProductEntity
			   (
				    1,
				   "ProductEntity 1",
				   true,
				   DateTime.Now,
				   DateTime.Now.AddYears(1),
				   "1",
				   "Supplier 1",
				   "12.345.678/0001-90"
			   ),

			   new ProductEntity
			   (
				    2,
				   "ProductEntity 2",
				   true,
				   DateTime.Now,
				   DateTime.Now.AddYears(1),
				   "2",
				   "Supplier 2",
				   "98.765.432/0001-09"
			   ),
			   new ProductEntity
			   (
				    3,
				   "ProductEntity 3",
				   true,
				   DateTime.Now,
				   DateTime.Now.AddYears(1),
				   "3",
				   "Supplier 3",
				   "12.345.678/0001-90"
			   ),
			   new ProductEntity
			   (
				    4,
				   "ProductEntity 4",
				   true,
				   DateTime.Now,
				   DateTime.Now.AddYears(1),
				   "4",
				   "Supplier 4",
				   "98.765.432/0001-09"
			   ),
			   new ProductEntity
			   (
				    5,
				   "ProductEntity 5",
				   true,
				   DateTime.Now,
				   DateTime.Now.AddYears(1),
				   "5",
				   "Supplier 5",
				   "12.345.678/0001-90"
			   ),
			   new ProductEntity
			   (
				    6,
				   "ProductEntity 6",
				   true,
				   DateTime.Now,
				   DateTime.Now.AddYears(1),
				   "6",
				   "Supplier 6",
				   "98.765.432/0001-09"
			   ),
			   new ProductEntity
			   (
				    7,
				   "ProductEntity 7",
				   true,
				   DateTime.Now,
				   DateTime.Now.AddYears(1),
				   "7",
				   "Supplier 7",
				   "12.345.678/0001-90"
			   ),
			   new ProductEntity
			   (
				    8,
				   "ProductEntity 8",
				   true,
				   DateTime.Now,
				   DateTime.Now.AddYears(1),
				   "8",
				   "Supplier 8",
				   "98.765.432/0001-09"
			   ),
			   new ProductEntity
			   (
				    9,
				   "ProductEntity 9",
				   true,
				   DateTime.Now,
				   DateTime.Now.AddYears(1),
				   "9",
				   "Supplier 9",
				   "12.345.678/0001-90"
			   ),
			   new ProductEntity
			   (
				    10,
				   "ProductEntity 10",
				   true,
				   DateTime.Now,
				   DateTime.Now.AddYears(1),
				   "10",
				   "Supplier 10",
				   "98.765.432/0001-09"
			   )
		   );
		}
		
	}
}
