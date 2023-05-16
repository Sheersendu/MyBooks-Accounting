namespace Backend.Business.Request;

public interface IRequestRepository
{
	public Task<Guid> AddRequest();
	public Task<IEnumerable<dynamic>> GetRequests();
}