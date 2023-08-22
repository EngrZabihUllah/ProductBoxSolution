
using Microsoft.EntityFrameworkCore;
using ProductBox_ExerciseSolution.Models;
using ProductBox_ExerciseSolution.DBContext;
using ProductBox_ExerciseSolution.Interfaces;


namespace ProductBox_ExerciseSolution.CustomerRepository
{
    public class RepoCustomer : ICustomer
    {
        private readonly CustomerContext _context;

        public RepoCustomer(CustomerContext context)
        {
            _context = context;
        }
        public async Task<Customer> GetByID(int customerId)
        {
            return await _context.Customer.FindAsync(customerId);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task Insert(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int customerId)
        {
            
            var customer = await _context.Customer.FindAsync(customerId);
            if (customer != null)
            {
                _context.Customer.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}