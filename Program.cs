using ContainerDemo.Domain;
using ContainerDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActionService _actionService = ActionService.GetInstance();
            
            List<Container> containers = _actionService.GetContainers();
            List<Invoice> invoices = _actionService.GetInvoices();

            Console.WriteLine("Containers and Invoices created successfully. Choose an action to continue");
            
            int actionResult = 1;

            do
            {
                Console.WriteLine("0. Display All Invoices");
                Console.WriteLine("1. Display All Containers");
                Console.WriteLine("2. Process Invoices - basic");
                Console.WriteLine("3. Process Invoices - tenor");
                Console.WriteLine("4. Process Invoices - balances");
                Console.WriteLine("5. Process Invoices - multiple currencies");
                Console.WriteLine("6. Exit");


                actionResult = Int32.Parse(Console.ReadLine());

                if (actionResult == 0)
                {
                    DisplayInvoices(invoices);
                }
                else if (actionResult == 1)
                {
                    DisplayContainers(containers);
                }
                else if (actionResult == 2)
                {
                    _actionService.ProcessInvoicesBasic(containers, invoices);
                    DisplayContainersAndInvoices(containers, invoices);
                }
                else if (actionResult == 3)
                {
                    _actionService.ProcessInvoicesTenor(containers, invoices);
                    DisplayContainersAndInvoices(containers, invoices);
                }
                else if (actionResult == 4)
                {
                    _actionService.ProcessInvoicesBalances(containers, invoices);
                    DisplayContainersAndInvoices(containers, invoices);
                }
                else if (actionResult == 5)
                {
                    _actionService.ProcessInvoicesMultipleCurrencies(containers, invoices);
                    DisplayContainersAndInvoices(containers, invoices);
                }
                else
                {
                    Environment.Exit(0);
                }

                

            } while (actionResult != 6);
            
        }
        private static void DisplayContainers(List<Container> containers)
        {
            Console.WriteLine();
            Console.WriteLine("***************** Containers *****************");
            foreach (var container in containers)
            {
                Console.WriteLine($"Container: {container.Name}, StartDate: {container.StartDate}, EndDate: {container.EndDate}, " +
                    $"MinTenor: {container.MinTenor}, MaxTenor: {container.MaxTenor}");

                var keys = container.CurrencyMaxAmount.Keys.ToList();
                foreach (var key in keys)
                {
                    Console.WriteLine($"Currency: {key}, MaxAmount: {container.CurrencyMaxAmount[key]}");
                    Console.WriteLine(".............................................................");

                }
            }
        }
        private static void DisplayInvoices(List<Invoice> invoices)
        {
            Console.WriteLine();
            Console.WriteLine("***************** Invoices *****************");

            foreach (var invoice in invoices)
            {
                Console.WriteLine($"Invoice Id: {invoice.Id}, Currency: {invoice.Currency}, DueDate: {invoice.DueDate}, ValueDate: {invoice.ValueDate}, " +
                    $"Amount: {invoice.Amount}");
                
            }
        }
        private static void DisplayContainersAndInvoices(List<Container> containers, List<Invoice> invoices)
        {
            foreach (var container in containers)
            {

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine($"Container: {container.Name}, StartDate: {container.StartDate}, EndDate: {container.EndDate}, " +
                    $"MinTenor: {container.MinTenor}, MaxTenor: {container.MaxTenor}");

                var keys = container.CurrencyMaxAmount.Keys.ToList();
                foreach (var key in keys)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Currency: {key}, MaxAmount: {container.CurrencyMaxAmount[key]}");
                    Console.WriteLine(".............................................................");

                    foreach (var invoice in container.Invoices.Where(i => i.Currency == key).ToList())
                    {
                        Console.WriteLine($"Invoice: {invoice.Id}, ValueDate: {invoice.ValueDate}, DueDate: {invoice.DueDate}, Currency: {invoice.Currency}, Amount: {invoice.Amount}");
                    }
                }

                Console.WriteLine("=============================================================");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
