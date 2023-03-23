using CustomerAPi.Model;

namespace CustomerAPi.Repository.IRepository
{
    public interface ICustomerRepository
    {
        Task AddCustomer(Customer customer);
    }
}
