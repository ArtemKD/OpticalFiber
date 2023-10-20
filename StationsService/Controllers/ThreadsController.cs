using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationsService.Services;

namespace StationsService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ThreadsController : ControllerBase
	{
		private readonly SheduleService _sheduleService;

		public ThreadsController(SheduleService sheduleService)
		{
			_sheduleService = sheduleService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok();
		}

		[HttpGet]
		[Route("{threadId}")]
		public async Task<IActionResult> GetThreadAsync(string threadId)
		{
			var routeThread = await _sheduleService.GetThreadStationsAsync(threadId);

			return Ok(routeThread);
		}
	}
}
