using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSoft.Invoices.Business.Services;
using BSoft.Invoices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSoft.Invoices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<tbl_customer>> Get()
        {
            return Ok(_customerService.ListCustomer());
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<tbl_customer>> Get(int id)
        {
            return Ok(_customerService.ListCustomerById(id));
        }
        [HttpPost]
        public ActionResult Post([FromBody] tbl_customer entity)
        {
            if (_customerService.RegisterCustomer(entity))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult Put([FromBody] tbl_customer entity)
        {
            if (_customerService.UpdateCustomer(entity))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (_customerService.DeleteCustomer(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}