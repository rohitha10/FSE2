using EStocksService.Model;
using EStocksService.Service.IRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EStocksService.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    //[Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepo _repository;

        public CompanyController(ICompanyRepo repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("api/v1.0/market/[controller]/Info/{CompanyCode}")]
        public Company Get(string CompanyCode)
        {
            var data = _repository.GetCompanyData(CompanyCode);
            return data;
        }

        [HttpPost]
        [Route("api/v1.0/market/[controller]/register")]
        public IActionResult Save(Company company)
        {
            var data = _repository.SaveCompany(company);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" +
                HttpContext.Request.Path + "/" + company.CompanyId, data);
        }


        [HttpGet]
        [Route("api/v1.0/market/[controller]/getall")]
        public IQueryable<Company> Get()
        {
            var data = _repository.GetCompanyDetails();
            //return Ok(data);
            return data;
        }

     
        [HttpDelete]
        [Route("api/v1.0/market/[controller]/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _repository.DeleteCompany(id);
            return NoContent();
        }
    }
}
