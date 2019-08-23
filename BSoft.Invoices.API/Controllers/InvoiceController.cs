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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<tbl_service>> Get()
        {
            return Ok(_invoiceService.ListInvoice());
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<tbl_service>> Get(int id)
        {
            return Ok(_invoiceService.ListInvoiceceById(id));
        }
        [HttpPost]
        public ActionResult Post([FromBody] tbl_invoice entity)
        {
            if (_invoiceService.RegisterInvoice(entity))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult Put([FromBody] tbl_invoice entity)
        {
            if (_invoiceService.UpdateInvoice(entity))
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
            if (_invoiceService.DeleteInvoice(id))
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