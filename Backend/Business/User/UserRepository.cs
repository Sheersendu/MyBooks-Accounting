using Backend.Business.Customer;
using Backend.Context;
using Backend.Models;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Backend.Business.User;

public class UserRepository : IUserRepository
{
	readonly DapperContext context;
	readonly IExpertRepository expertRepository;
	readonly ICustomerRepository customerRepository;

	const string createUserSql =
		@"INSERT INTO [dbo].[User] VALUES(NEWID(), @Username, @HashedPassword, @IsExpert, @CreatedTime);";

	const string getUserSql = @"SELECT User_Password FROM [dbo].[User] WHERE User_ID = @Username;";

	public UserRepository(DapperContext context, IExpertRepository expertRepository, ICustomerRepository customerRepository)
	{
		this.context = context;
		this.expertRepository = expertRepository;
		this.customerRepository = customerRepository;
	}

	public async Task<bool> CreateUser(UserRegistration user)
	{
		var hashedPassword = PasswordHasher.HashPassword(user.Password);
		var userCreatedTime = DateTime.UtcNow;
		try
		{
			await context.CreateConnection().QueryAsync(createUserSql, new
			{
				user.Username,
				HashedPassword = hashedPassword,
				IsExpert = user.IsExpert,
				CreatedTime = userCreatedTime
			});
			if (user.IsExpert)
			{
				await expertRepository.AddExpert(user.Username);
			}
			else
			{
				await customerRepository.AddCustomer(user.Username);
			}

			return true;
		}
		catch
		{
			return false;
		}
	}

	public async Task<bool> ValidateUser(UserLogin user)
	{
		Console.WriteLine(user.Username+":"+user.Password);
		var hashedPassword = context.CreateConnection().QueryAsync<string>(getUserSql, new
		{
			user.Username
		}).Result.ToList()[0];
		return PasswordHasher.VerifyPassword(user.Password, hashedPassword);
	}
}