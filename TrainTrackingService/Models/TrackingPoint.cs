namespace TrainTrackingService.Models
{
	public class TrackingPoint
	{
		public Guid Id { get; set; }
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public DateTime DateTime { get; set; }
	}
}
