using Microsoft.AspNetCore.Mvc;
using Backend.Business;

namespace Backend.Controllers
{
	[ApiController]
	[Route("expert")]
	public class ExpertController: ControllerBase
	{
		private readonly IExpertRepository expertRepo;

		public ExpertController(IExpertRepository expertRepo)
		{
			this.expertRepo = expertRepo;
		}

		// [HttpGet("")]
		// public async Task<IActionResult> GetExperts()
		// {
		// 	try
		// 	{
		// 		var experts = await expertRepo.GetExperts();
		// 		return Ok(experts);
		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		//log error
		// 		return StatusCode(500, ex.Message);
		// 	}
		// }

		[HttpPost("")]
		public async Task<ActionResult> AddExpert([FromHeader] int expId)
		{
			try
			{
				await expertRepo.AddExpert(expId);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}