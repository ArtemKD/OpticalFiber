using Domain.Entities;
using Domain.Models;

namespace StationsService.Interfaces
{
	public interface IStationRepository
	{
		Task<Station?> CreateAsync(Station station);
		Task<Station?> UpdateAsync(Station station);
		bool Delete(Guid id);

		Task<IEnumerable<StationPoint>> GetPointsInArea(MapArea area, int limit, int offset);
		Task<Station?> GetStationAsync(Guid id);
		Task<Station?> GetStationByCodeAsync(string id);
		Task<int> GetStationCountAsync(MapArea area);
	}
}
