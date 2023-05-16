namespace Backend.Business.CustomerRequest;

public interface ICustomerRequest
{
	public Task CustomerRequestMap(Guid custId, Guid reqId);
	public Task<IEnumerable<dynamic>> GetCustomerRequest(Guid custPk);
}