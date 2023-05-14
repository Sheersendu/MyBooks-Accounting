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

		[HttpPost("newRequest")]
		public async Task<ActionResult> AddCustomerRequest([FromHeader] int custId)
		{
			try
			{
				await customerRepo.AddCustomerRequest(custId);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}