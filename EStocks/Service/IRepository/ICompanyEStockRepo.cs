using EStocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStocks.Service.IRepository
{
   public  interface ICompanyEStockRepo
    {
        public CompanyEStock SaveCompanyEStock(CompanyEStock companyEStock);

        public IQueryable<CompanyEStock> GetCompanyData(string Code,DateTime startdate,DateTime enddate);
    }
}
