using CustomerAPi.Data;
using CustomerAPi.Model;
using CustomerAPi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPi.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomer(Customer customer)
        {
            var vehicleInDb = await _context.Vehicles.
               FirstOrDefaultAsync(v => v.Id == customer.VehicleId);
            if (vehicleInDb == null)
            {
                await _context.Vehicles.AddAsync(customer.Vehicle);
                await _context.SaveChangesAsync();
            }
            customer.Vehicle = null;
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            //Azure 
        }
    }
}
