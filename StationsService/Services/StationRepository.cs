using AutoMapper;
using Domain.Entities;
using Domain.Models;
using StationsService.Database;
using StationsService.Interfaces;

using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace StationsService.Services
{
	public class StationRepository : IStationRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public StationRepository(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Station?> CreateAsync(Station station)
		{
			throw new NotImplementedException();
		}

		public async Task<Station?> UpdateAsync(Station station)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<StationPoint>> GetPointsInArea(MapArea area, int limit, int offset)
		{
			var polyArea = new Polygon(new LinearRing(new[]
			{
				new Coordinate(area.Left, area.Top),
				new Coordinate(area.Right, area.Top),
				new Coordinate(area.Right, area.Bottom),
				new Coordinate(area.Left, area.Bottom),
				new Coordinate(area.Left, area.Top)
			}));

			var areaCenter = new Point(Math.Abs(area.Right) - Math.Abs(area.Left), Math.Abs(area.Top) - Math.Abs(area.Bottom));

			var stations = await _context.Stations
				.Where(e => polyArea.Contains(e.Location))
				.OrderBy(e => e.Location.Distance(areaCenter))
				.Skip(offset)
				.Take(limit)
				.ProjectTo<StationPoint>(_mapper.ConfigurationProvider)
				.ToListAsync();
			return stations;
		}

		public async Task<Station?> GetStationAsync(Guid id)
		{
			var station = await _context.Stations
				.Where(e => e.Id == id)
				.ProjectTo<Station>(_mapper.ConfigurationProvider)
				.FirstOrDefaultAsync();

			return station;
		}

		public async Task<Station?> GetStationByCodeAsync(string code)
		{
			var station = await _context.Stations
				.Where(e => e.YandexCode == code)
				.ProjectTo<Station>(_mapper.ConfigurationProvider)
				.FirstOrDefaultAsync();

			return station;
		}

		public async Task<int> GetStationCountAsync(MapArea area)
		{
			var polyArea = new Polygon(new LinearRing(new[]
			{
				new Coordinate(area.Left, area.Top),
				new Coordinate(area.Right, area.Top),
				new Coordinate(area.Right, area.Bottom),
				new Coordinate(area.Left, area.Bottom),
				new Coordinate(area.Left, area.Top)
			}));

			return await _context.Stations
				.Where(e => polyArea.Contains(e.Location))
				.CountAsync();
		}
	}
}
