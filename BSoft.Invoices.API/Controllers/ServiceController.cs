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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<tbl_service>> Get()
        {
            return Ok(_serviceService.ListService());
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<tbl_service>> Get(int id)
        {
            return Ok(_serviceService.ListServiceById(id));
        }
        [HttpPost]
        public ActionResult Post([FromBody] tbl_service entity)
        {
            if (_serviceService.RegisterService(entity))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult Put([FromBody] tbl_service entity)
        {
            if (_serviceService.UpdateService(entity))
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
            if (_serviceService.DeleteService(id))
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