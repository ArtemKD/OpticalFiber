using Newtonsoft.Json;

namespace StationsService.Models.Deserialize.ThreadStationsResponce
{
	/// <summary>
	/// Класс, содержащий информацию об остановке конкретного маршрута
	/// </summary>
	public class ThreadStop
	{
		public DateTime? Arrival { get; set; }

		public DateTime? Departure { get; set; }

		public double Duration { get; set; }

		[JsonProperty("stop_time")]
		public int? StopTime { get; set; }

		public ThreadStationInfo Station { get; set; }
	}
}
