using Microsoft.AspNetCore.Mvc;

namespace TrainTrackingService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TrainsController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok();
		}
	}
}
