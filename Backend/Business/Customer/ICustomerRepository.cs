namespace Backend.Business.Customer
{
	public interface ICustomerRepository
	{
		public Task AddCustomer(string custId);
		public Task AddCustomerRequest(int custId, string requestName);
		public Task<IEnumerable<dynamic>> GetCustomerRequests(int custId);
	}
}
