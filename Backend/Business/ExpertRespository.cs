using Backend.Context;
using Backend.Models;
using Dapper;

namespace Backend.Business;

public class ExpertRepository : IExpertRepository
{
	private readonly DapperContext _context;
	public ExpertRepository(DapperContext context)
	{
		_context = context;
	}
	
	public async Task<IEnumerable<Expert>> GetExperts()
	{
		var query = "SELECT * FROM Expert";
		using (var connection = _context.CreateConnection())
		{
			var experts = await connection.QueryAsync<Expert>(query);
			return experts.ToList();
		}
	}
}