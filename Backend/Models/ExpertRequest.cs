using Dapper.Contrib.Extensions;

namespace Backend.Models
{
	[Table(nameof(ExpertRequest))]
	public class ExpertRequest
	{
		[ExplicitKey]
		public Guid ExpReq_PK { get; set; }

		public Guid ExpReq_Exp_ID { get; set; }
		public Guid ExpReq_Req_ID { get; set; }
		public DateTime ExpReq_CreatedUtc { get; set; }
	}
}
