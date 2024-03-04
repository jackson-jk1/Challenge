
using Challenge.Api.AutoMapper;
using Challenge.Infrastructure.Context;
using Challenge.Infrastructure.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using System;
using Challenge.Infrastructure.Middwares;

namespace Challenge.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

	
		public void ConfigureServices(IServiceCollection services)
        {

			services.AddDbContext<SqliteContext>(options =>
		        options.UseSqlite(Configuration.GetConnectionString("DefaultConnectionString")));
			services.AddControllers();

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Challenge.Api",
					Description = "Api do desafio",
					TermsOfService = new Uri("https://example.com/terms"),
					Contact = new OpenApiContact
					{
						Name = "Example Contact",
						Url = new Uri("https://example.com/contact")
					},
					License = new OpenApiLicense
					{
						Name = "Example License",
						Url = new Uri("https://example.com/license")
					}
				});


		
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				options.IncludeXmlComments(xmlPath);
			
			});
			
			services.AddSingleton(AutoMapperConfig.RegisterMappings());

			ConfigurationIOC.AddConfigurationIOC(services);

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
			app.UseSwagger(c =>
			{
				c.SerializeAsV2 = true;
			});
			if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Challenge.Api v1"));
            }

            app.UseHttpsRedirection();

			app.UseMiddleware<ErrorHandlingMiddleware>();

			app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
