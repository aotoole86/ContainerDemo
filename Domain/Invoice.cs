using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerDemo.Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
