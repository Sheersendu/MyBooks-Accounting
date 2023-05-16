namespace Backend.Business.Customer
{
	public interface ICustomerRepository
	{
		public Task AddCustomer(int custId);
		public Task AddCustomerRequest(int custId);
		public Task<IEnumerable<dynamic>> GetCustomerRequests(int custId);
	}
}
