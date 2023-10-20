using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationsService.Interfaces;
using StationsService.Models.ApiResponses;

namespace StationsService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StationsController : ControllerBase
	{
		private readonly IStationRepository _stationRepository;

		public StationsController(IStationRepository stationRepository, ILogger<StationsController> logger)
		{
			_stationRepository = stationRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetPointsAsync([FromQuery]MapArea area, int limit = 100, int offset = 0)
		{
			var stations = await _stationRepository.GetPointsInArea(area, limit, offset);
			var totalCount = await _stationRepository.GetStationCountAsync(area);

			var response = new PointsInAreaResponse
			{
				Pagination = new Pagination
				{
					Total = totalCount,
					Limit = limit,
					Offset = offset
				},
				Points = stations
			};

			return Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetStationAsync(Guid id)
		{
			var station = await _stationRepository.GetStationAsync(id);
			if (station == null)
			{
				return BadRequest("Station not found.");
			}
			return Ok(station);
		}

		[HttpGet]
		[Route("ByCode/{code}")]
		public async Task<IActionResult> GetStationByCodeAsync(string code)
		{
			var station = await _stationRepository.GetStationByCodeAsync(code);

			if (station == null)
			{
				return BadRequest("Station not found.");
			}

			return Ok(station);
		}
	}
}
