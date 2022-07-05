using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStocks.Model
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyOwner { get; set; }
        public int CompanyTurnover { get; set; }
        public string Website { get; set; }
        public int StockExchangeType { get; set; }
    }
}
