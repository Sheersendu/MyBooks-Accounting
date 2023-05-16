using Backend.Business.CustomerRequest;
using Backend.Business.Request;
using Backend.Context;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Backend.Business.Customer;

public class CustomerRepository:ICustomerRepository
{
	readonly DapperContext context;
	readonly IRequestRepository requestRepo;
	readonly ICustomerRequest custReqRepo;

	public CustomerRepository(DapperContext context, IRequestRepository requestRepo, ICustomerRequest custReqRepo)
	{
		this.context = context;
		this.requestRepo = requestRepo;
		this.custReqRepo = custReqRepo;
	}

	const string getCustomer = @"SELECT Cust_PK from Customer WHERE Cust_ID = @custID;";

	public async Task AddCustomer(int custId)
	{
		var customer = new Models.Customer
		{
			Cust_PK = Guid.NewGuid(),
			Cust_ID = custId,
			Cust_IsActive = true,
			Cust_CreatedUtc = DateTime.UtcNow
		};
		await context.CreateConnection().InsertAsync(customer);
	}

	public async Task AddCustomerRequest(int custId)
	{
		var requestPk = await requestRepo.AddRequest();
		var customerPk = context.CreateConnection().QueryAsync(getCustomer, new {custID = custId}).Result.First().Cust_PK;
		custReqRepo.CustomerRequestMap(customerPk, requestPk);
	}

	public async Task<IEnumerable<dynamic>> GetCustomerRequests(int custId)
	{
		var customerPk = context.CreateConnection().QueryAsync(getCustomer, new {custID = custId}).Result.First().Cust_PK;
		return await custReqRepo.GetCustomerRequest(customerPk);
	}
}