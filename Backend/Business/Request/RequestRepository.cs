using Backend.Context;
using Backend.Services;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Backend.Business.Request;

public class RequestRepository:IRequestRepository
{
	readonly DapperContext context;
	readonly QueueService service;
	

	const string AddRequestQuery = @"INSERT INTO Request 
	OUTPUT INSERTED.Req_ID
	VALUES (@Req_pk, @IsCompleted, @CreatedTime);";

	public RequestRepository(DapperContext context, QueueService service)
	{
		this.context = context;
		this.service = service;
	}
	
	public async Task AddRequest()
	{
		var reqPk = Guid.NewGuid();
		var reqCreatedTime = DateTime.UtcNow;
		var reqId = await context.CreateConnection().QueryAsync<int>(AddRequestQuery, new
		{
			Req_pk = reqPk,
			IsCompleted = false,
			CreatedTime = reqCreatedTime
		});
		var request = new Models.Request
		{
			Req_PK = reqPk,
			Req_ID = reqId.AsList()[0],
			Req_IsCompleted = false,
			Req_CreatedUtc = reqCreatedTime
		};
		service.AddRequest(request);
	}
}