namespace StationsService.Models.Schedules
{
	public class Schedule
	{
		public string? ExceptDays { get; set; }

		public DateTime? Arrival { get; set; }

		public DateTime? Departure { get; set; }

		public Thread Thread { get; set; }
	}
}
