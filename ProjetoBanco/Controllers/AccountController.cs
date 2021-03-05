using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayerService.Interfaces;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using LayerDataBase.Model;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoBanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // GET: api/<AccountController>

        private IBankAccountService _bankAccount;

        public AccountController(IBankAccountService bankAccount)
        {
            _bankAccount = bankAccount;
        }

        [HttpGet]
        public ActionResult<List<BankAccount>> Get()
        {
            //HttpRequestMessage request = new HttpRequestMessage();
            try
            {
                var getAll = _bankAccount.Get().ToList();

                
                var getSee = Request;
                //request.Headers = getSee.Headers;

                return Ok(getAll);

                //return request.CreateResponse(HttpStatusCode.OK, getAll);

            }
            catch (Exception ex)
            {

                //return request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        // GET api/<AccountController>/5
        //[HttpGet("{id}")]
        [System.Web.Http.HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<string> Post(JsonElement value)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(value);
                var getRealdata = JsonConvert.DeserializeObject<BankAccount>(json);

                var getReturn = _bankAccount.Add(getRealdata);

                return "saved with success!";
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
               
            }
        }

        // PUT api/<AccountController>/5
        //[HttpPut("{id}")]
        [AllowAnonymous]
        [HttpPut]
        
        public ActionResult<string> Put(int id, JsonElement value)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(value);
                var getRealdata = JsonConvert.DeserializeObject<BankAccount>(json);

                var getReturn = _bankAccount.Update(getRealdata, id);

                return Ok(getReturn);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }

        // DELETE api/<AccountController>/5
        //[HttpDelete("{id}")]
        [HttpDelete]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _bankAccount.DeleteById(id);

                return Ok(new { message = "Account Deleted with Success" });
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }
    }
}
