using Microsoft.AspNetCore.Mvc;
using Backend.Business;
using Backend.Business.ExpertRequest;

namespace Backend.Controllers
{
	[ApiController]
	[Route("expert")]
	public class ExpertController: ControllerBase
	{
		readonly IExpertRepository expertRepo;
		readonly IExpertRequest expertRequest;

		public ExpertController(IExpertRepository expertRepo, IExpertRequest expertRequest)
		{
			this.expertRepo = expertRepo;
			this.expertRequest = expertRequest;
		}

		[HttpGet("requests")]
		public async Task<ObjectResult> GetExpertRequests([FromHeader] int expId)
		{
			try
			{
				var result = await expertRequest.GetExpertRequest(expId);
				return Ok(result);
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}

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