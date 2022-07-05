using EStocks.Model;
using EStocks.Service.IRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EStocks.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CompanyEStockController : ControllerBase
    {
        private readonly ICompanyEStockRepo _repository;

        public CompanyEStockController(ICompanyEStockRepo repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("api/v1.0/market/[controller]/AddStock")]
        public IActionResult Save(CompanyEStock companyStock)
        {
            var data = _repository.SaveCompanyEStock(companyStock);
            if (data != null)
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" +
                    HttpContext.Request.Path + "/" + companyStock.CompanyId, data);
            else
                return null;
        }

        [HttpGet]
        [Route("api/v1.0/market/[controller]/{CompanyCode}/{startdate}/{enddate}")]
        public IQueryable<CompanyEStock> Get(string CompanyCode, DateTime startdate, DateTime enddate)
        {
            var data = _repository.GetCompanyData(CompanyCode, startdate, enddate);
            return data;
        }
    }
}
