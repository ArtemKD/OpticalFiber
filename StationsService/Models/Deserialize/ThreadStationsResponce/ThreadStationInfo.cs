using Newtonsoft.Json;

namespace StationsService.Models.Deserialize.ThreadStationsResponce
{
	/// <summary>
	/// Информация о станции остановки конкретного маршрута
	/// </summary>
	public class ThreadStationInfo
	{
		public string Title { get; set; }

		[JsonProperty("station_type")]
		public string StationType { get; set; }

		[JsonProperty("popular_title")]
		public string PopularTitle { get; set; }

		[JsonProperty("short_title")]
		public string ShortTitle { get; set; }

		public string Code { get; set; }
	}
}
