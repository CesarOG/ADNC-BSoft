using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSoft.Invoices.API.ViewObject;
using BSoft.Invoices.Business;
using BSoft.Invoices.Business.Services;
using BSoft.Invoices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSoft.Invoices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : BaseController
    {
        //private readonly IInvoiceService _invoiceService;
        //public InvoiceController(IInvoiceService invoiceService)
        //{
        //    _invoiceService = invoiceService;
        //}

        public InvoiceController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<InvoiceVO>> Get()
        {
            //return Ok(_invoiceService.ListInvoice());

            var invoices = _unitOfWork.Invoice.ListInvoice();

            List<InvoiceVO> response = new List<InvoiceVO>();
            foreach (var item in invoices)
            {
                InvoiceVO obj = new InvoiceVO()
                {
                    cliente = new CustomerVO()
                    {
                        codigo = item.idcustomer
                    },
                    producto = new ServiceVO()
                    {
                        codigo = item.idservice
                    },
                    codigo = item.idinvoice,
                    estado = (item.ispay ? "1" : "0"),
                    monto = item.residuetotal
                };
                response.Add(obj);
            }


            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<tbl_service>> Get(int id)
        {
            //return Ok(_invoiceService.ListInvoiceceById(id));
            return Ok();
        }
        [HttpPost]
        public ActionResult Post([FromBody] tbl_invoice entity)
        {
            //if (_invoiceService.RegisterInvoice(entity))
            //{
            //    return Ok();
            //}
            //else
            //{
            //    return BadRequest();
            //}
            return Ok();
        }
        [HttpPut]
        public ActionResult Put([FromBody] tbl_invoice entity)
        {
            //if (_invoiceService.UpdateInvoice(entity))
            //{
            //    return Ok();
            //}
            //else
            //{
            //    return BadRequest();
            //}
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            //if (_invoiceService.DeleteInvoice(id))
            //{
            //    return Ok();
            //}
            //else
            //{
            //    return BadRequest();
            //}

            return Ok();
        }



    }
}