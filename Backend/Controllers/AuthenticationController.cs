using Backend.Business.User;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("user")]
public class AuthenticationController : ControllerBase
{
	readonly IUserRepository userRepository;

	public AuthenticationController(IUserRepository userRepository)
	{
		this.userRepository = userRepository;
	}
	
	[HttpPost("register")]
	public async Task<ActionResult<Response>> CreateUser(UserRegistration user)
	{
		var response = await userRepository.CreateUser(user);
		return new Response
		{
			IsAunthenticated = response,
			Message = response ? "" : "Unable to create user at the moment, please try again in sometime."
		};
	}
	
	[HttpPost("login")]
	public async Task<ActionResult<Response>> GetUserByUsername(UserLogin user)
	{
		var response = await userRepository.ValidateUser(user);
		return new Response
		{
			IsAunthenticated = response,
			Message = response ? "" : "Invalid credentials."
		};
	}
}