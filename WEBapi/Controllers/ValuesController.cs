using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WEBapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        // GET api/values
        [HttpGet]
        public List<Customer> Get()
        {
            
            using(DBContent dbContent = new DBContent())
            {
               return dbContent.GetCustomerList();
            }
            
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            using(DBContent content = new DBContent())
            {
                return content.GetCustomer(id);
            }
        }

       [HttpPost]
       public void Post([FromBody]Customer customer)
       {
            using(DBContent content = new DBContent())
            {
                content.UpdateCustomer(customer.ID,customer.Name,customer.SurName,customer.Age,customer.Payment,customer.Adress);
            }
       }
    }
}
