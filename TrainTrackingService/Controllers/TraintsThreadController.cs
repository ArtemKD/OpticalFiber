using Microsoft.AspNetCore.Mvc;
using TrainTrackingService.Services;

namespace TrainTrackingService.Controllers
{
	[Route("api/trains")]
	[ApiController]
	public class TraintsThreadController : ControllerBase
	{
		private readonly SheduleService _sheduleService;

		public TraintsThreadController(SheduleService sheduleService)
		{
			_sheduleService = sheduleService;
		}

		[HttpGet]
		[Route("{stationCode}")]
		public async Task<IActionResult> Get(string stationCode)
		{
			var text = await _sheduleService.GetThreads(stationCode);
			return Ok(text);
		}

		[HttpGet]
		[Route("/thread/{threadCode}")]
		public async Task<IActionResult> ThreadInfo(string threadCode)
		{
			var text = await _sheduleService.GetThreadInfo(threadCode);
			return Ok(text);
		}
	}
	/*
	 {
  "id": "b2bf96d0-3278-4103-9ea4-aae54ddc06cd",
  "title": "Москва (Белорусский вокзал)",
  "direction": "Белорусское",
  "stationType": "train_station",
  "transportType": "train",
  "longitude": 37.57958027843418,
  "latitude": 55.7764527677074,
  "esrCode": "198230",
  "yandexCode": "s2000006"
}
	 */
}
