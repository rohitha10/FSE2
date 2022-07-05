using EStocks.Model;
using EStocks.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStocks.Service.Repository
{
    public class CompanyEStockRepo : ICompanyEStockRepo
    {
        private readonly DbContexts _context;
        public CompanyEStockRepo(DbContexts context)
        {
            _context = context;
        }
        public IQueryable<CompanyEStock> GetCompanyData(string Code, DateTime startdate, DateTime enddate)
        {

            int companyId = GetCompanyCodeById(Code);
            if (companyId == null || companyId == 0)
                return null;
            else
                return _context.CompanyEStock.Where(x => x.CompanyId == companyId &&
                            x.StartDate.Date <= startdate.Date && x.EndDate.Date <= enddate.Date);
        }

        private int GetCompanyCodeById(string code)
        {
            Company company = _context.Company.FirstOrDefault(x => x.CompanyCode == code);
            return company.CompanyId;
        }

        public CompanyEStock SaveCompanyEStock(CompanyEStock companyEStock)
        {
            if (companyEStock != null)
            {
                _context.Add(companyEStock);
                _context.SaveChanges();
                return companyEStock;
            }
            else
                return null;
         
        }
    }
}
