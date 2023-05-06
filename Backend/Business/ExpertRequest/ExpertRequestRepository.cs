using Backend.Context;
using Backend.Models;
using Dapper;

namespace Backend.Business.ExpertRequest;

public class ExpertRequestRepository : IExpertRequest
{
	readonly DapperContext context;
	
	const string GetExpertsListQuery = @"
	SELECT 
		Exp_PK,
		Exp_ID,
		Exp_IsActive,
		Exp_CreatedUtc
	FROM Expert;";

	const string MapRequestToExpertQuery = @"INSERT INTO ExpertRequest VALUES(NEWID(), @ExpId, @ReqId, @ExpReq_CreatedTime)";

	public ExpertRequestRepository(DapperContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<Expert>> GetExperts()
	{
		using var connection = context.CreateConnection();
		var experts = await connection.QueryAsync<Expert>(GetExpertsListQuery);
		return experts;
	}

	public async Task MapRequestToExpert(Guid expId, Guid reqId)
	{
		await context.CreateConnection().ExecuteAsync(MapRequestToExpertQuery, new
		{
			ExpId = expId,
			Req_Id = reqId,
			ExpReq_CreatedTime = DateTime.UtcNow
		});
	}
}