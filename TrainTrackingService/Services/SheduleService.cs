namespace TrainTrackingService.Services
{
	public class SheduleService
	{
		private readonly ILogger<SheduleService> _logger;
		private readonly HttpClient _httpClient;

		public SheduleService(ILogger<SheduleService> logger, HttpClient httpClient)
		{
			_logger = logger;
			_httpClient = httpClient;
		}

		public async Task<string> GetThreads(string stationCode)
		{
			var responce = await _httpClient.GetAsync($"schedule/?station={stationCode}");

			if (!responce.IsSuccessStatusCode)
			{
				return "Not success";
			}

			var text = await responce.Content.ReadAsStringAsync();

			return text;	
		}

		public async Task<string> GetThreadInfo(string threadCode)
		{
			var responce = await _httpClient.GetAsync($"thread/?uid={threadCode}");

			if (!responce.IsSuccessStatusCode)
			{
				return "Not success";
			}

			var text = await responce.Content.ReadAsStringAsync();

			return text;
		}
	}
}
