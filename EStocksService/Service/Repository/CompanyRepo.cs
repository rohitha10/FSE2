using EStocksService.Model;
using EStocksService.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStocksService.Service.Repository
{
    public class CompanyRepo: ICompanyRepo
    {
        private readonly CompanyDbContext _context;
        public CompanyRepo(CompanyDbContext context)
        {
            _context = context;
        }

        public Company GetCompanyById(int companyCode)
        {
            return _context.Company.FirstOrDefault(x => x.CompanyId == companyCode);
        }

        public void DeleteCompany(int companyCode)
        {
            Company company = GetCompanyById(companyCode);
            _context.Remove(company);
            _context.SaveChanges();
        }

        public IQueryable<Company> GetCompanyDetails()
        {
            return _context.Company;
        }

        public Company SaveCompany(Company company)
        {
            _context.Add(company);
            _context.SaveChanges();
            return company;
        }
        public Company GetCompanyData(string code)
        {

            var company = _context.Company.FirstOrDefault(x => x.CompanyCode == code);
            return company;
        }
        
    }
}
