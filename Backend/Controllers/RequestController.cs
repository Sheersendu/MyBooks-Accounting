using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.IO;
using Backend.Business;
using Backend.Business.Request;
using Backend.Models;

namespace Backend.Controllers
{
	[ApiController]
	[Route("request")]
	public class RequestController: ControllerBase
	{
		private readonly IRequestRepository requestRepo;

		public RequestController(IRequestRepository requestRepo)
		{
			this.requestRepo = requestRepo;
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
		public async Task<ActionResult> AddExpert()
		{
			try
			{
				await requestRepo.AddRequest();
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}