using ContainerDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerDemo.Contracts.Interfaces
{
    public interface IActionService
    {
        Invoice CreateInvoice(int containerId, DateTime valueDate, DateTime dueDate, string currency, decimal amount);
        //Container CreateContainer(string name, DateTime startDate, DateTime startTime, DateTime endDate, DateTime endTime, string currency, decimal minTenor, decimal maxTenor, decimal maxAmount);
        Container CreateContainer(string name, DateTime startDate, DateTime startTime, DateTime endDate, DateTime endTime, Dictionary<string, decimal> currencyMaxAmount, decimal minTenor, decimal maxTenor);
        List<Container> GetContainers();
        List<Invoice> GetInvoices();
        void ProcessInvoicesBasic(List<Container> containers, List<Invoice> invoices);
        void ProcessInvoicesTenor(List<Container> containers, List<Invoice> invoices);
        void ProcessInvoicesBalances(List<Container> containers, List<Invoice> invoices);
        void ProcessInvoicesMultipleCurrencies(List<Container> containers, List<Invoice> invoices);

    }
}
