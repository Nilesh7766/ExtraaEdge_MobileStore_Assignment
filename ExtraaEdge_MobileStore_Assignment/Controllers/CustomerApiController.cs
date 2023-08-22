using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtraaEdge_MobileStore_Assignment.Models;
using ExtraaEdge_MobileStore_Assignment.BlRepository;

namespace ExtraaEdge_MobileStore_Assignment.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        Repository<TblCustomer, int> _customerRepo;
        public CustomerApiController()
        {
            this._customerRepo = new Repository<TblCustomer, int>();
        }
        [HttpGet]
        [Route("api/Customers")]
        public List<TblCustomer> GetAllCustomers()
        {
            List<TblCustomer> lst = _customerRepo.GetAll();
            return lst;
        }

        [HttpGet]
        [Route("api/Customers/{id}")]
        public TblCustomer GetCustomersById(int id)
        {
            return _customerRepo.GetById(id);
        }

        [HttpPost]
        [Route("api/Customers")]
        public string AddCustomers(TblCustomer c)
        {
            _customerRepo.Create(c);
            return "Customer Add Successfully...";
        }
        [HttpPut]
        [Route("api/Customers")]
        public string UpdateCustomerSuccess(TblCustomer c)
        {
            _customerRepo.Update(c);
            return "Update Customer Successfully..";
        }
        [HttpDelete]
        [Route("api/Customers/{id}")]
        public string DeleteCustomer(int id)
        {
            var customer = _customerRepo.GetById(id);
            _customerRepo.Delete(id);
            return "Customer Delete Successfully";
        }



    }
}
