using Backend.Context;
using Dapper.Contrib.Extensions;

namespace Backend.Business.CustomerRequest;

public class CustomerRequestRepository:ICustomerRequest
{
	readonly DapperContext context;

	const string AddCustomerRequest = @"INSERT INTO CustomerRequest VALUES (NEWID(), @custID, @reqID, @taskID, @status, @@CreatedTime)";

	public CustomerRequestRepository(DapperContext context)
	{
		this.context = context;
	}

	public async Task CustomerRequestMap(Guid custId, Guid reqId)
	{
		var createdTime = DateTime.UtcNow;
		for (var i = 1; i < 5; i++)
		{
			var customerRequest = new Models.CustomerRequest
			{
				CustReq_PK = Guid.NewGuid(),
				CustReq_Cust_ID = custId,
				CustReq_Req_ID = reqId,
				CustReq_TASK_ID = i,
				CustReq_STATUS = false,
				CustReq_CreatedUtc = createdTime
			};
			await context.CreateConnection().InsertAsync(customerRequest);
		}
	}
}