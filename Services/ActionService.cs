using ContainerDemo.Contracts.Interfaces;
using ContainerDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ContainerDemo.Services
{
    public sealed class ActionService : IActionService
    {

        private static ActionService _instance;
        private ActionService(){}
        public static ActionService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ActionService();
            }
            return _instance;
        }


        //public Container CreateContainer(string name, DateTime startDate, DateTime startTime, DateTime endDate, DateTime endTime, string currency, decimal minTenor, decimal maxTenor, decimal maxAmount)
        //{
        //    return (new Container
        //    {
        //        Id = 1,
        //        Name = name,
        //        StartDate = startDate,
        //        StartTime = startTime,
        //        EndDate = endDate,
        //        EndTime = endTime,
        //        Currency = currency,
        //        MinTenor = minTenor,
        //        MaxTenor = maxTenor,
        //        MaxAmount = maxAmount,
        //        Invoices = new List<Invoice>()
        //    });
        //}

        public Container CreateContainer(string name, DateTime startDate, DateTime startTime, DateTime endDate, DateTime endTime, Dictionary<string, decimal> currencyMaxAmount, decimal minTenor, decimal maxTenor)
        {
            return new Container
            {
                Id = 1,
                Name = name,
                StartDate = startDate,
                StartTime = startTime,
                EndDate = endDate,
                EndTime = endTime,
                CurrencyMaxAmount = currencyMaxAmount,
                MinTenor = minTenor,
                MaxTenor = maxTenor,
                Invoices = new List<Invoice>()
            };
        }
        public Invoice CreateInvoice(int id, DateTime valueDate, DateTime dueDate, string currency, decimal amount)
        {
            return (new Invoice
            {
                Id = id,
                ValueDate = valueDate,
                DueDate = dueDate,
                Currency = currency,
                Amount = amount
            });
        }

        public List<Container> GetContainers()
        {
            List<Container> _containers = new List<Container>();
            
            _containers.Add(CreateContainer("USD 0-30", DateTime.Today, DateTime.Today, DateTime.Today.AddDays(30), DateTime.Today.AddDays(30), new Dictionary<string, decimal> { { "USD", 1000000 } }, 1, 30));
            _containers.Add(CreateContainer("USD 31-60", DateTime.Today.AddDays(31), DateTime.Today.AddDays(31), DateTime.Today.AddDays(60), DateTime.Today.AddDays(60), new Dictionary<string, decimal> { { "USD", 1000000 } }, 1, 30));
            _containers.Add(CreateContainer("USD 61-90", DateTime.Today.AddDays(61), DateTime.Today.AddDays(61), DateTime.Today.AddDays(90), DateTime.Today.AddDays(90), new Dictionary<string, decimal> { { "USD", 1000000 } }, 1, 30));

            _containers.Add(CreateContainer("JPY 0-30", DateTime.Today, DateTime.Today, DateTime.Today.AddDays(30), DateTime.Today.AddDays(30), new Dictionary<string, decimal> { { "JPY", 1000000 } }, 1, 30));
            _containers.Add(CreateContainer("JPY 31-60", DateTime.Today.AddDays(31), DateTime.Today.AddDays(31), DateTime.Today.AddDays(60), DateTime.Today.AddDays(60), new Dictionary<string, decimal> { { "JPY", 1000000 } }, 1, 30));

            _containers.Add(CreateContainer("EUR|BRL 0-30", DateTime.Today, DateTime.Today, DateTime.Today.AddDays(30), DateTime.Today.AddDays(30), new Dictionary<string, decimal> { { "EUR", 1000000 }, { "BRL", 500000} }, 1, 30));
            

            return _containers;
        }

        public List<Invoice> GetInvoices()
        {
            List<Invoice> _invoices = new List<Invoice>();

            _invoices.Add(CreateInvoice(1, DateTime.Today, DateTime.Today.AddDays(30), "USD", 10000));
            _invoices.Add(CreateInvoice(2, DateTime.Today, DateTime.Today.AddDays(5), "USD", 123450));
            _invoices.Add(CreateInvoice(3, DateTime.Today, DateTime.Today.AddDays(15), "USD", 123450));
            _invoices.Add(CreateInvoice(4, DateTime.Today.AddDays(10), DateTime.Today.AddDays(15), "USD", 543021));
            _invoices.Add(CreateInvoice(5, DateTime.Today, DateTime.Today.AddDays(33), "USD", 20000));
            _invoices.Add(CreateInvoice(6, DateTime.Today, DateTime.Today.AddDays(37), "USD", 20500));
            _invoices.Add(CreateInvoice(7, DateTime.Today.AddDays(38), DateTime.Today.AddDays(52), "USD", 22000));
          
            _invoices.Add(CreateInvoice(8, DateTime.Today.AddDays(32), DateTime.Today.AddDays(60), "USD", 55000));
            _invoices.Add(CreateInvoice(9, DateTime.Today.AddDays(61), DateTime.Today.AddDays(79), "USD", 130000));
            _invoices.Add(CreateInvoice(10, DateTime.Today.AddDays(38), DateTime.Today.AddDays(42), "USD", 130000));

            _invoices.Add(CreateInvoice(11, DateTime.Today, DateTime.Today.AddDays(30), "JPY", 100000));
            _invoices.Add(CreateInvoice(12, DateTime.Today, DateTime.Today.AddDays(5), "JPY", 123405));
            _invoices.Add(CreateInvoice(13, DateTime.Today, DateTime.Today.AddDays(15), "JPY", 12345));
            _invoices.Add(CreateInvoice(14, DateTime.Today.AddDays(10), DateTime.Today.AddDays(15), "JPY", 543021));
            _invoices.Add(CreateInvoice(15, DateTime.Today, DateTime.Today.AddDays(33), "JPY", 20000));
            _invoices.Add(CreateInvoice(16, DateTime.Today, DateTime.Today.AddDays(37), "JPY", 250000));
            _invoices.Add(CreateInvoice(17, DateTime.Today.AddDays(38), DateTime.Today.AddDays(52), "JPY", 22000));
            _invoices.Add(CreateInvoice(18, DateTime.Today.AddDays(34), DateTime.Today.AddDays(60), "JPY", 55000));
            _invoices.Add(CreateInvoice(19, DateTime.Today.AddDays(61), DateTime.Today.AddDays(79), "JPY", 130000));
            _invoices.Add(CreateInvoice(20, DateTime.Today.AddDays(31), DateTime.Today.AddDays(74), "JPY", 430000));

            _invoices.Add(CreateInvoice(21, DateTime.Today, DateTime.Today.AddDays(30), "EUR", 100330));
            _invoices.Add(CreateInvoice(22, DateTime.Today, DateTime.Today.AddDays(5), "EUR", 123453));
            _invoices.Add(CreateInvoice(23, DateTime.Today, DateTime.Today.AddDays(15), "EUR", 123453));
            _invoices.Add(CreateInvoice(24, DateTime.Today, DateTime.Today.AddDays(15), "EUR", 534321));
            _invoices.Add(CreateInvoice(25, DateTime.Today, DateTime.Today.AddDays(33), "EUR", 200033));

            _invoices.Add(CreateInvoice(26, DateTime.Today, DateTime.Today.AddDays(5), "BRL", 250000));
            _invoices.Add(CreateInvoice(27, DateTime.Today, DateTime.Today.AddDays(15), "BRL", 100000));
            _invoices.Add(CreateInvoice(28, DateTime.Today, DateTime.Today.AddDays(15), "BRL", 100000));
            _invoices.Add(CreateInvoice(29, DateTime.Today, DateTime.Today.AddDays(15), "BRL", 100000));

            

            return _invoices;
        }

        public void ProcessInvoicesBalances(List<Container> containers, List<Invoice> invoices)
        {
            /*
             * 
             * Each container has a max limit, ensure that the addition of invoice always keeps the containers in balance 
             * Eg: Two containers are active and have limits of 1 million and 3 Million each, 
             * containers are considered to be in balance if container 1 has invoices worth 500K and container 2 has invoices worth 1.5 million. 
             * If container 1 has 600K, then container 2 has 1.8 million
             * 
             * NOTE :4/18/2025 not sure if the requirements are correct,I may be making an assumption
             * 
             */

            foreach (var i in invoices)
            {
                foreach (var c in containers)
                {
                    try
                    {
                        if (c.CurrencyMaxAmount.ContainsKey(i.Currency) && i.ValueDate >= c.StartDate && i.ValueDate < c.EndDate && c.CurrencyMaxAmount[i.Currency] >= c.Invoices.Where(o => o.Currency == i.Currency).Sum(o => o.Amount) + i.Amount)
                        {
                            c.Invoices.Add(i);
                        }
                    }
                    catch (KeyNotFoundException)
                    {
                        //log and continue
                    }
                    
                }
            }
        }

        public void ProcessInvoicesBasic(List<Container> containers, List<Invoice> invoices)
        {
            foreach (var i in invoices)
            {
                foreach (var c in containers)
                {
                    if (c.CurrencyMaxAmount.ContainsKey(i.Currency) && i.ValueDate >= c.StartDate && i.ValueDate < c.EndDate)
                    {
                        c.Invoices.Add(i);
                    }
                }
            }
        }

        public void ProcessInvoicesMultipleCurrencies(List<Container> containers, List<Invoice> invoices)
        {
            foreach (var i in invoices)
            {
                foreach (var c in containers)
                {
                    try
                    {
                        if (c.CurrencyMaxAmount.ContainsKey(i.Currency) && i.ValueDate >= c.StartDate && i.ValueDate < c.EndDate && c.CurrencyMaxAmount[i.Currency] > c.Invoices.Where(o => o.Currency == i.Currency).Sum(o => o.Amount) + i.Amount)
                        {
                            c.Invoices.Add(i);
                        }
                    }
                    catch (KeyNotFoundException)
                    {
                        //log and continue
                    }
                    
                }
            }
        }

        public void ProcessInvoicesTenor(List<Container> containers, List<Invoice> invoices)
        {
            foreach (var i in invoices)
            {
                foreach (var c in containers)
                {
                    if (!c.CurrencyMaxAmount.ContainsKey(i.Currency) && i.ValueDate >= c.StartDate && i.ValueDate < c.EndDate && TenorPasses(i, c))
                    {
                        c.Invoices.Add(i);
                    }
                }
            }
        }

        private bool TenorPasses(Invoice i, Container c)
        {
            if ((i.DueDate - DateTime.Today).Days < c.MinTenor || (i.DueDate - DateTime.Today).Days > c.MaxTenor)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
