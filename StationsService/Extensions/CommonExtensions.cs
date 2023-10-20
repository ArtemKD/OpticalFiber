using Microsoft.EntityFrameworkCore;
using StationsService.Database;
using StationsService.Interfaces;
using StationsService.MappingProfiles;
using StationsService.Services;

namespace StationsService.Extensions
{
	public static class CommonExtensions
	{
		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IStationRepository, StationRepository>();
		}

		public static void AddMappingProfiles(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(EfMapperProfile), typeof(StationProfile));
		}

		public static void AddPostgresContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("PostgresConnection") ?? throw new ArgumentNullException("Empty db connection string.");
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseNpgsql(connectionString, o => o.UseNetTopologySuite());
			});
		}

		public static void AddSheduleService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<SheduleService>();

			services.AddHttpClient<SheduleService>(client =>
			{
				client.BaseAddress = new Uri("https://api.rasp.yandex.net/v3.0/");
				var yadexKey = configuration["YandexApiKey"] ?? throw new ArgumentNullException("YandexApiKey is null");
				client.DefaultRequestHeaders.Add("Authorization", yadexKey);
			});
		}
	}
}
