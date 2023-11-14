using Domain.Models;
using Newtonsoft.Json;
using StationsService.Interfaces;
using StationsService.Models.Deserialize.ThreadStationsResponce;

namespace StationsService.Services
{
	public class SheduleService
	{
		private readonly HttpClient _client;
		private readonly IStationRepository _stationRepository;

		public SheduleService(HttpClient client, IStationRepository stationRepository)
		{
			_client = client;
			_stationRepository = stationRepository;
		}

		public async Task<RouteThread?> GetThreadStationsAsync(string threadId)
		{
			var response = await _client.GetAsync($"thread/?uid={threadId}", HttpCompletionOption.ResponseHeadersRead);

			var stream = await response.Content.ReadAsStreamAsync();

			var serialiser = new JsonSerializer();
			using (var reader = new StreamReader(stream))
			using (var jsonReader = new JsonTextReader(reader))
			{
				var threadInfo = serialiser.Deserialize<ThreadInfo>(jsonReader);

				if (threadInfo == null)
					return null;

				var stops = new List<StationStop>();

				if (threadInfo.Stops == null)
					return null;

				foreach (var stop in threadInfo.Stops)
				{
					var stationPoint = await _stationRepository.GetStationByCodeAsync(stop.Station.Code);
					if (stationPoint != null)
					{
						stops.Add(new StationStop
						{
							Arrival = stop.Arrival,
							Departure = stop.Departure,
							Duration = stop.Duration,
							StopTime = stop.StopTime,
							StationPoint = new StationPoint
							{
								Id = stationPoint.Id,
								Title = stationPoint.Title,
								Longitude = stationPoint.Longitude,
								Latitude = stationPoint.Latitude,
							}
						});
					}
				}

				return new RouteThread
				{
					Uid = threadInfo.Uid,
					Title = threadInfo.Title,
					Number = threadInfo.Number,
					Stops = stops.ToArray(),
				};
				
			}
		}
	}
}
