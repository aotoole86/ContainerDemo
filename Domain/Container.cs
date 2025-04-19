using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerDemo.Domain
{
    public class Container
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndTime { get; set; }
        public Dictionary<string,decimal> CurrencyMaxAmount { get; set; }
        public decimal  MinTenor { get; set; }
        public decimal MaxTenor { get; set; }
        //public decimal MaxAmount { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
