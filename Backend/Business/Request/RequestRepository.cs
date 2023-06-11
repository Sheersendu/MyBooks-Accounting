using Backend.Context;
using Backend.Services;
using Dapper;

namespace Backend.Business.Request;

public class RequestRepository:IRequestRepository
{
	readonly DapperContext context;
	readonly QueueService service;

	const string getAllRequests = @"
	SELECT
		r.Req_ID,
		r.Req_Name,
		r.Req_IsCompleted
	FROM Request r
	WHERE r.Req_IsCompleted = 0;";

	const string AddRequestQuery = @"INSERT INTO Request 
	OUTPUT INSERTED.Req_ID
	VALUES (@Req_pk, @Req_name, @IsCompleted, @CreatedTime);";

	public RequestRepository(DapperContext context, QueueService service)
	{
		this.context = context;
		this.service = service;
	}
	
	public async Task<Guid> AddRequest(string requestName)
	{
		var reqPk = Guid.NewGuid();
		var reqCreatedTime = DateTime.UtcNow;
		var reqId = await context.CreateConnection().QueryAsync<int>(AddRequestQuery, new
		{
			Req_pk = reqPk,
			Req_name = requestName,
			IsCompleted = false,
			CreatedTime = reqCreatedTime
		});
		var request = new Models.Request
		{
			Req_PK = reqPk,
			Req_ID = reqId.AsList()[0],
			Req_Name = requestName,
			Req_IsCompleted = false,
			Req_CreatedUtc = reqCreatedTime
		};
		service.AddRequest(request);
		return reqPk;
	}

	public async Task<IEnumerable<dynamic>> GetRequests()
	{
		return await context.CreateConnection().QueryAsync(getAllRequests);
	}
}