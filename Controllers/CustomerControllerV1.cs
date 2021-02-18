using ApiJul.Models;
using ApiJul.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiJul.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    public class CustomerControllerV1 : BaseController<Customer>
    {
        public CustomerControllerV1()
        {
            _repo = new CustomersRepository();
            baseUrl = "api/v1/customer/{0}";
        }
    }
}
