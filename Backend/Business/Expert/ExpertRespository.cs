using Backend.Context;
using Backend.Models;
using Dapper;

namespace Backend.Business
{
	public class ExpertRepository : IExpertRepository
	{
		readonly DapperContext context;

		const string GetExpertsListQuery = @"
	SELECT 
		EXP_PK,
		EXP_ID,
		EXP_CreatedUtc
	FROM Expert;";

		const string AddExpertQuery = @"INSERT INTO Expert VALUES (NEWID(), @ExpID, @ExpCreatedTime);";

		public ExpertRepository(DapperContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<Expert>> GetExperts()
		{
			using var connection = context.CreateConnection();
			// var sqlPath = Path.Combine(Environment.CurrentDirectory, "Scripts", "CreateTables.sql");
			// var sqlFile = await File.ReadAllTextAsync(sqlPath);
			// connection.Execute(sqlFile);
			var experts = await connection.QueryAsync<Expert>(GetExpertsListQuery);
			return experts.ToList();
		}

		public async Task AddExpert(int expId)
		{
			await context.CreateConnection().ExecuteAsync(AddExpertQuery, new
			{
				ExpID = expId,
				ExpCreatedTime = DateTime.UtcNow
			});
		}
	}
}