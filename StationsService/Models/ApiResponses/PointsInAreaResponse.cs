using Domain.Models;

namespace StationsService.Models.ApiResponses
{
	public class PointsInAreaResponse
	{
		public Pagination Pagination { get; set; }

		public IEnumerable<StationPoint>? Points { get; set; }

		public PointsInAreaResponse()
		{
			Pagination = new Pagination();
			Points = null;
		}
	}
}
