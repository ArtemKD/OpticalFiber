
namespace Domain.Models
{
	public class RouteThread
	{
		public string Uid { get; set; }

		public string Title { get; set; }

		public string Number { get; set; }

		public StationStop[] Stops { get; set; }
	}
}
