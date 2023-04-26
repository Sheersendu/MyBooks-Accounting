using Dapper.Contrib.Extensions;
namespace Backend.Models
{
	[Table(nameof(Expert))]
	public class Expert
	{
		[ExplicitKey]
		public Guid EXP_PK { get; set; }

		public int EXP_ID { get; set; }
		public DateTime EXP_CreatedUtc { get; set; } = DateTime.UtcNow;
	}
}
