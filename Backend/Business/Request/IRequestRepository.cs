namespace Backend.Business.Request;

public interface IRequestRepository
{
	public Task<Guid> AddRequest(string requestName);
	public Task<IEnumerable<dynamic>> GetRequests();
}