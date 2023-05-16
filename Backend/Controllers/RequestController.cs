using Backend.Business.Request;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	[ApiController]
	[Route("request")]
	public class RequestController:ControllerBase
	{
		readonly IRequestRepository requestRepo;

		public RequestController(IRequestRepository requestRepo)
		{
			this.requestRepo = requestRepo;
		}

		[HttpGet("")]
		public async Task<ObjectResult> GetAllRequests()
		{
			try
			{
				var result = await requestRepo.GetRequests();
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}