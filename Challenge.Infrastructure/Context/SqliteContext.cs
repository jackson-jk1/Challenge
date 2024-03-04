using Challenge.Domain.Entities;
using Challenge.Infrastructure.Context.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infrastructure.Context
{
	public class SqliteContext : DbContext
	{
		

		public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
		{
		}

		public DbSet<ProductEntity> Products { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new ProductSeed());
			
		}

		
	}
}
