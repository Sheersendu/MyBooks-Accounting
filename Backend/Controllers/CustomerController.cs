using Microsoft.AspNetCore.Mvc;
using Backend.Business.Customer;

namespace Backend.Controllers
{
	[ApiController]
	[Route("customer")]
	public class CustomerController: ControllerBase
	{
		readonly ICustomerRepository customerRepo;

		public CustomerController(ICustomerRepository expertRepo)
		{
			this.customerRepo = expertRepo;
		}

		[HttpPost("")]
		public async Task<ActionResult> AddCustomer([FromHeader] int custId)
		{
			try
			{
				await customerRepo.AddCustomer(custId);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		[HttpPost("request")]
		public async Task<ActionResult> AddCustomerRequest([FromHeader] int custId, [FromHeader] string requestName)
		{
			try
			{
				await customerRepo.AddCustomerRequest(custId, requestName);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		
		[HttpGet("requests")]
		public async Task<ActionResult> GetCustomerRequests([FromHeader] int custId)
		{
			try
			{
				var result = await customerRepo.GetCustomerRequests(custId);
				return new OkObjectResult(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}