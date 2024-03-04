
using Challenge.Api.Request.DTOs;

using Challenge.Api.Request.Validation;
using Challenge.Application.Interfaces;
using Challenge.Application.Services;
using Challenge.Domain.Interfaces.Base;
using Challenge.Infrastructure.Repositories.Base;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.Infrastructure.IOC
{
	public static class ConfigurationIOC
	{

		public static void AddConfigurationIOC(IServiceCollection services)
		{


			#region Services

			services.AddScoped<IProductService, ProductService>();

			#endregion
			#region Validators
	
			services.AddTransient<IValidator<ProductFilterDTO>, SelectProductsValidation>();
			services.AddTransient<IValidator<ProductInsertDTO>, ProductInsertValidation>();
			services.AddTransient<IValidator<ProductDTO>, ProductValidation>();
		
			#endregion

			#region Repositorys


			services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

			#endregion

			

		}
	}
}
