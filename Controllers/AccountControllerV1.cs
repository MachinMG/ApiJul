using ApiJul.Models;
using ApiJul.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiJul.Controllers
{

    [Route("api/v1/account")]
    [ApiController]
    public class AccountControllerV1 : ControllerBase
    {
        protected IRepository<Account> _repo;
        protected string baseUrl;

        public AccountControllerV1()
        {
            _repo = new AccountRepository();
        }

        [HttpPost("validate/{idCustomer}/{password}")]
        public virtual IActionResult Post(Guid idCustomer, string password)
        {
            var account = _repo.Get().FirstOrDefault(a => a.IdCustomer == idCustomer);
            if (account == null) return NotFound($"Account for customer {idCustomer} not found.");
            if (account.Password == EncodeSha256WithSalt(password))
            {
                return Ok();
            }
            else
            {
                return Unauthorized("Wrong password");
            }
        }

        [HttpPut("set/{idCustomer}/{password}")]
        public IActionResult Put(Guid idCustomer, string password)
        {
            var account = _repo.Get().FirstOrDefault(a => a.IdCustomer == idCustomer);
            if (account == null)
            {
                var newAccount = new Account() { IdCustomer = idCustomer, Password = EncodeSha256WithSalt(password) };
                var validations = newAccount.Validate();
                if (validations.Any()) return BadRequest(string.Join(" ", validations));
                else _repo.Create(newAccount);
            }
            else
            {
                account.Password = EncodeSha256WithSalt(password);
                _repo.Update(account);
            }
            return Ok();
        }

        [HttpDelete("{idCustomer}")]
        public virtual void Delete(Guid idCustomer)
        {
            var account = _repo.Get().FirstOrDefault(a => a.IdCustomer == idCustomer);
            if(account!=null) _repo.Delete(account.Id);
        }

        private string EncodeSha256WithSalt(string value)
        {
            value = $"ApplIc4Tion{value}P0uRJul";
            using (SHA256 mySHA = SHA256.Create())
            {
                return Convert.ToBase64String(mySHA.ComputeHash(Encoding.UTF8.GetBytes(value)));
            }
        }
    }
}
