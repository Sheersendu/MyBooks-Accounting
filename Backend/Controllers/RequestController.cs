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
		readonly IRequestRepository requestRepo;

		public RequestController(IRequestRepository requestRepo)
		{
			this.requestRepo = requestRepo;
		}

		[HttpPost("")]
		public async Task<ActionResult> AddExpert()
		{
			try
			{
				return new OkObjectResult(await requestRepo.AddRequest());
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}