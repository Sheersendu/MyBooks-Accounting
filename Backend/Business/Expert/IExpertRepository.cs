using Backend.Models;

namespace Backend.Business;

public interface IExpertRepository
{
	public Task<IEnumerable<Expert>> GetExperts();
}