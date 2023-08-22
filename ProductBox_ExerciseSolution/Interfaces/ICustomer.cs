using ProductBox_ExerciseSolution.Models;

namespace ProductBox_ExerciseSolution.Interfaces
{
    public interface ICustomer
    {

        Task<Customer> GetByID(int customerId);
        Task<IEnumerable<Customer>> GetAll();
        Task Insert(Customer customer);
        Task Update(Customer customer);
        Task Delete(int customerId);
    }
}
