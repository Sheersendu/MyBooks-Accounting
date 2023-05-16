using Dapper.Contrib.Extensions;

namespace Backend.Models
{
	[Table(nameof(Customer))]
	public class Customer
	{
		[ExplicitKey]
		public Guid Cust_PK { get; set; }

		public int Cust_ID { get; set; }
		public bool Cust_IsActive { get; set; }
		public DateTime? Cust_CreatedUtc { get; set; } = DateTime.UtcNow;
	}
}

