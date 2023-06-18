using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace Backend.Models;

[Table(nameof(User))]
public class User
{
	[ExplicitKey]
	public Guid User_PK { get; set; }

	public string User_ID { get; set; }

	public string? User_Password { get; set; }
	
	public bool User_IsExpert { get; set; }

	public DateTime User_CreatedUtc { get; set; } = DateTime.UtcNow;
}