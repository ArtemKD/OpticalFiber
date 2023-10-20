using Newtonsoft.Json;

namespace StationsService.Models.Deserialize.ThreadStationsResponce
{
	/// <summary>
	/// Информация о маршруте
	/// </summary>
	public class ThreadInfo
	{
		public string Uid { get; set; }

		public string Title { get; set; }

		public string Number { get; set; }

		[JsonProperty("short_title")]
		public string ShortTitle { get; set; }

		public ThreadStop[] Stops { get; set; }

		public string Vehicle { get; set; }
	}
}
