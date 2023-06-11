using Backend.Context;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Backend.Business.CustomerRequest;

public class CustomerRequestRepository:ICustomerRequest
{
	readonly DapperContext context;

	const string getCustomerRequest = @"SELECT
	Req_Name,
	CustReq_TASK_ID,
	CustReq_STATUS 
FROM CustomerRequest 
JOIN Request
ON CustReq_Req_ID = Req_PK
WHERE CustReq_Cust_ID = @custID
GROUP BY Req_Name, CustReq_Req_ID, CustReq_TASK_ID, CustReq_STATUS;";

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

	public async Task<IEnumerable<dynamic>> GetCustomerRequest(Guid custPk)
	{
		var result = await context.CreateConnection().QueryAsync(getCustomerRequest, new { custID = custPk });
		var r = result.GroupBy(
			request => request.CustReq_TASK_ID
		);
		return result;
	}
}