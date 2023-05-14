namespace Backend.Business.Customer;

public interface ICustomerRepository
{
	public Task AddCustomer(int custId);
	public Task AddCustomerRequest(int custId);
}