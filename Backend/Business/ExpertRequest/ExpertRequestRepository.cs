using Backend.Context;
using Backend.Models;
using Dapper;
using Dapper.Contrib.Extensions;

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

	const string getExpertRequest = @"
	SELECT 
		r.Req_ID, 
		r.Req_IsCompleted 
	FROM ExpertRequest er
	JOIN Expert e
	ON e.Exp_PK = er.ExpReq_Exp_ID
	JOIN Request r 
	ON er.ExpReq_Req_ID = r.Req_PK
	WHERE e.Exp_ID = @ExpPk;";

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
		var expertRequest = new Models.ExpertRequest
		{
			ExpReq_PK = Guid.NewGuid(),
			ExpReq_Exp_ID = expId,
			ExpReq_Req_ID = reqId,
			ExpReq_CreatedUtc = DateTime.UtcNow
		};
		await context.CreateConnection().InsertAsync(expertRequest);
	}

	public async Task<IEnumerable<dynamic>> GetExpertRequest(int expId)
	{
		return await context.CreateConnection().QueryAsync(getExpertRequest, new
		{
			ExpPk = expId
		});
	}
}