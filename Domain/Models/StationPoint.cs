
namespace Domain.Models
{
	public class StationPoint
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public double Longitude { get; set; }
		public double Latitude { get; set; }
	}
}
