using Discount.Store.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Store.Infrastructure
{
	public static class StartupSetup
	{
		public static void AddDbContext(this IServiceCollection services, string connectionString) =>
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(connectionString));
	}
}
