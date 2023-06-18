using Backend.Models;

namespace Backend.Business.User;

public interface IUserRepository
{
	public Task<bool> CreateUser(UserRegistration user);

	public Task<bool> ValidateUser(UserLogin user);
}