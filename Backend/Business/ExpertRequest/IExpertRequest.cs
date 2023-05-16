using Backend.Models;

namespace Backend.Business.ExpertRequest;

public interface IExpertRequest
{
	public Task<IEnumerable<Expert>> GetExperts();
	public Task MapRequestToExpert(Guid expId, Guid reqId);
	public Task<IEnumerable<dynamic>> GetExpertRequest(int expId);
}