namespace StationsService.Models.Schedules
{
	public class SchedulesByStation
	{
		public DateOnly? Date { get; set; }

		public Pagination Pagination { get; set; }

		public Schedule[] Schedule { get; set; }
	}
}
