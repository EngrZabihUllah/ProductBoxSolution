using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductBox_ExerciseSolution.Models;
using ProductBox_ExerciseSolution.Interfaces;
using ProductBox_ExerciseSolution.CustomerRepository;

namespace ProductBox_ExerciseSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerRepository;

        public CustomerController(ICustomer customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/customers

        [HttpGet]
        [Route("Index")]
        public async Task<ActionResult<IEnumerable<Customer>>> Index()
        {
            try
            {
                var customers = await _customerRepository.GetAll();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
            
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        [Route("GetCustomerByID")]
        public async Task<ActionResult<Customer>> GetCustomerByID(int id)
        {
            
            try
            {
                var customer = await _customerRepository.GetByID(id);
                if (customer == null)
                {
                    return NotFound("Customer Record Not Found in Database...");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // POST: api/customers
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<ActionResult> AddCustomer(Customer customer)
        {
            
            try
            {
                await _customerRepository.Insert(customer);
                
                return CreatedAtAction(nameof(GetCustomerByID), new { id = customer.Id }, customer);

                 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


        }

        // PUT: api/customers/{id}
        [HttpPut("{id}")]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            try
            {
                if (id != customer.Id)
                {
                    return BadRequest("Customer ID is not Valid!");
                }
                await _customerRepository.Update(customer);
                 
                return Ok("Record Updated Successfully...");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
           

            
        }

        // DELETE: api/customers/{id}
        [HttpDelete("{id}")]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer = await _customerRepository.GetByID(id);
                if (customer == null)
                {
                    return NotFound("Customer Record Not Found in Database...");
                }

                await _customerRepository.Delete(id);

                return Ok("Record Deleted Successfully...");
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
            
        }

    }
}
