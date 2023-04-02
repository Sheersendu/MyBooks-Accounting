using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.IO;
using Backend.Business;
using Backend.Models;

namespace Backend.Controllers
{
	[ApiController]
	[Route("expert")]
	public class ExpertController: ControllerBase
	{
		private readonly IExpertRepository _expertRepo;
		public ExpertController(IExpertRepository expertRepo)
		{
			_expertRepo = expertRepo;
		}
		[HttpGet("")]
		public async Task<IActionResult> Get()
		{
			// var connection = new SqlConnection("Server=.; Database=Demo; User Id= Password=;");
			// var sqlPath = Path.Combine(Environment.CurrentDirectory, "Scripts", "Createtables.sql");
			// var sqlFile = System.IO.File.ReadAllText(sqlPath);
			// connection.Execute(sqlFile);
			// return connection.Query<Expert>("SELECT * FROM Expert");
			try
			{
				var experts = await _expertRepo.GetExperts();
				return Ok(experts);
			}
			catch (Exception ex)
			{
				//log error
				return StatusCode(500, ex.Message);
			}
		}
	}
}