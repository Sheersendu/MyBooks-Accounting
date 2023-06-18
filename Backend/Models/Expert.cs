using Dapper.Contrib.Extensions;

namespace Backend.Models
{
	[Table(nameof(Expert))]
	public class Expert
	{
		[ExplicitKey]
		public Guid Exp_PK { get; set; }

		public string Exp_ID { get; set; }
		public bool Exp_IsActive { get; set; }
		public DateTime Exp_CreatedUtc { get; set; } = DateTime.UtcNow;
	}
}
