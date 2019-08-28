using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSoft.Invoices.API.ViewObject;
using BSoft.Invoices.Business;
using BSoft.Invoices.Business.Services;
using BSoft.Invoices.Models;
using BSoft.Invoices.Models.Beans;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSoft.Invoices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
        [Authorize]
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


            return Ok(response);
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
        [HttpPost]
        [Route("PayDebt/")]
        public IActionResult PayDebt([FromBody]  InvoiceVO entity)
        {
            var response = _unitOfWork.Invoice.PayInvoice(entity.codigo, entity.producto.codigo, entity.cliente.codigo).FirstOrDefault();
            TransactionVO transaction = new TransactionVO();
            if (response == "0000")
            {
                transaction.Code = response;
                transaction.Description = "Operacion Exitosa";
            }
            else
            {
                transaction.Code = "1111";
                transaction.Description = "Error en la operacion";
            }
            return Ok(new { result = transaction.Code, message = transaction.Description });
        }

        [HttpPost]
        [Route("ReversePayment/")]
        public IActionResult ReversePayment([FromBody]  InvoiceVO entity)
        {
            string response = _unitOfWork.Invoice.ReversePay(entity.codigo, entity.producto.codigo, entity.cliente.codigo).FirstOrDefault();
            TransactionVO transaction = new TransactionVO();
            if (response == "0000")
            {
                transaction.Code = response;
                transaction.Description = "Operacion Exitosa";
            }
            else
            {
                transaction.Code = "1111";
                transaction.Description = "Error en la operacion";
            }
            return Ok(new { result = transaction.Code, message = transaction.Description });
        }

        [HttpGet]
        [Route("ListDebts/{customerId}")]
        public IActionResult ListDebts(int customerId)
        {
            List<InvoiceVO> listResponse = new List<InvoiceVO>();
            var result = _unitOfWork.Invoice.ListInvoicesByCustomer(customerId);

            foreach (InvoiceBean item in result)
            {
                InvoiceVO invoiceVO = new InvoiceVO()
                {
                    codigo = item.InvoiceId,
                    monto = item.ResidueTotal,
                    estado = (item.IsPay ? "1" : "0"),
                    cliente = new CustomerVO()
                    {
                        nombres = item.ContactName,
                        codigo = item.CustomerId,
                        empresa = item.BusinessName
                    },
                    producto = new ServiceVO()
                    {
                        codigo = item.serviceid,
                        descripcion = item.description,
                        precio = item.Price.ToString()
                    }
                };
                listResponse.Add(invoiceVO);
            }
            return Ok(listResponse);
        }


    }
}