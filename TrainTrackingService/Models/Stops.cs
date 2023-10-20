namespace TrainTrackingService.Models
{
	public class Stops
	{
		public Guid Id { get; set; }

		public DateTime Arrival { get; set; }

		public DateTime Departure { get; set; }

		public int Duration { get; set; }

		public int StopTime { get; set; }

		public string Title { get; set; }

		public string Code { get; set; }
	}
}
