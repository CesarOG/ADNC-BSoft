using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSOFT.Security.Business.Services;
using BSOFT.Security.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSOFT.Security.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<tbl_company>> Get()
        {
            return Ok(_companyService.ListCompany());
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<tbl_company>> Get(int id)
        {
            return Ok(_companyService.ListCompanyById(id));
        }
        [HttpPost]
        public ActionResult Post([FromBody] tbl_company entity)
        {
            if (_companyService.RegisterCompany(entity))
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