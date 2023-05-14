using Dapper.Contrib.Extensions;
namespace Backend.Models
{
	[Table(nameof(CustomerRequest))]
	public class CustomerRequest
	{
		[ExplicitKey]
		public Guid CustReq_PK { get; set; }

		public Guid CustReq_Cust_ID { get; set; }
		public Guid CustReq_Req_ID { get; set; }
		public int CustReq_TASK_ID { get; set; }
		public bool CustReq_STATUS { get; set; }
		public DateTime? CustReq_CreatedUtc { get; set; } = DateTime.UtcNow;
	}
}