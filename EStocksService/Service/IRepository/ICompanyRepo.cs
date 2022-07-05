using EStocksService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStocksService.Service.IRepository
{
   public  interface ICompanyRepo
    {
        public IQueryable<Company> GetCompanyDetails();
        public Company SaveCompany(Company company);
        public Company GetCompanyById(int id);
        public void DeleteCompany(int companyCode);
        public Company GetCompanyData(string Code);
    }
}
