using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStocks.Model
{
    public class DbContexts : DbContext
    {
        public DbContexts(DbContextOptions<DbContexts> options) : base(options)
        {

        }

        public DbSet<CompanyEStock> CompanyEStock { get; set; }

        public DbSet<Company> Company { get; set; }

    }
}
