using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;

namespace Backend.Models
{
	[Dapper.Contrib.Extensions.Table(nameof(Request))]
	public class Request
	{
		[ExplicitKey]
		public Guid Req_PK { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Req_ID { get; set; }

		public string Req_Name { get; set; }

		public bool Req_IsCompleted { get; set; }
		public DateTime Req_CreatedUtc { get; set; } = DateTime.UtcNow;
	}
}