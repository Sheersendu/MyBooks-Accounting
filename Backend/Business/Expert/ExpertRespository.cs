using Backend.Context;
using Backend.Models;
using Backend.Services;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Backend.Business
{
	public class ExpertRepository : IExpertRepository
	{
		readonly DapperContext context;
		readonly QueueService service;

		const string GetExpertsListQuery = @"
	SELECT 
		Exp_PK,
		Exp_ID,
		Exp_IsActive,
		Exp_CreatedUtc
	FROM Expert;";

		public ExpertRepository(DapperContext context, QueueService service)
		{
			this.context = context;
			this.service = service;
		}

		public async Task<IEnumerable<Expert>> GetExperts()
		{
			using var connection = context.CreateConnection();
			var sqlPath = Path.Combine(Environment.CurrentDirectory, "Scripts", "CreateTables.sql");
			var sqlFile = await File.ReadAllTextAsync(sqlPath);
			connection.Execute(sqlFile);
			var experts = await connection.QueryAsync<Expert>(GetExpertsListQuery);
			return experts;
		}

		public async Task AddExpert(int expId)
		{
			var expert = new Expert
			{
				Exp_PK = Guid.NewGuid(),
				Exp_ID = expId,
				Exp_IsActive = true,
				Exp_CreatedUtc = DateTime.UtcNow
			};
			await context.CreateConnection().InsertAsync(expert);
			service.AddExpert(expert);
		}
	}
}