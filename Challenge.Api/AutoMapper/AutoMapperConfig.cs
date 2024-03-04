using AutoMapper;
using Challenge.Api.Request.DTOs;
using Challenge.Domain.Entities;

namespace Challenge.Api.AutoMapper
{
	public sealed class AutoMapperConfig
	{
		public static IMapper RegisterMappings()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<ProductEntity, ProductDTO>();
				// Adicione outros mapeamentos conforme necessário
			});

			return config.CreateMapper();
		}
	}
}
