using System.Text.Json.Serialization;

namespace StationsService.Models.Schedules
{
	public class Thread
	{
		public string Uid { get; set; }

		public string Title { get; set; }

		public string Number { get; set; }

		public string ShortTitle { get; set; }

		public string TransportType { get; set; }

		public string Vehicle { get; set; }
	}
}
