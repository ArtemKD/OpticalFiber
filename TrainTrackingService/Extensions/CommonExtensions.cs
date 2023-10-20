using TrainTrackingService.Services;

namespace TrainTrackingService.Extensions
{
	public static class CommonExtensions
	{
		public static void AddTypedClients(this IServiceCollection services)
		{
			services.AddHttpClient<SheduleService>(client =>
			{
				client.BaseAddress = new Uri("https://api.rasp.yandex.net/v3.0/");
				client.DefaultRequestHeaders.Add("Authorization", "d841396e-5a80-4b6d-b939-1f99ea53e227");
			});
		}

		public static void AddCommponServices(this IServiceCollection services)
		{
			services.AddScoped<SheduleService>();
		}
	}
}
