using Newtonsoft.Json;

namespace Domain.Models
{
	public class StationStop
	{
		public DateTime? Arrival { get; set; }

		public DateTime? Departure { get; set; }

		public double Duration { get; set; }

		public int? StopTime { get; set; }

		public StationPoint StationPoint { get; set; }
	}
}
