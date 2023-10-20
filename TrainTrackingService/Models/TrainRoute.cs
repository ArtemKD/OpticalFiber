namespace TrainTrackingService.Models
{
	public class TrainRoute
	{
		public int Id { get; set; }
		public string ThreadId { get; set; }
		public List<TrackingPoint> Points { get; set; }
	}
}
