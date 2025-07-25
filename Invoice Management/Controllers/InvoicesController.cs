using Invoice_Management.Models;
using Invoice_Management.Services;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_Management.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext context;

        public InvoicesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var invoices = context.Invoices.OrderByDescending(inv => inv.Id).ToList();
            return View(invoices);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(InvoiceDbo invoiceDbo)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var invoice = new Invoice
            {
                Number = invoiceDbo.Number,
                status = invoiceDbo.status,
                IssueDate = invoiceDbo.IssueDate,
                DueDate = invoiceDbo.DueDate,
                Services = invoiceDbo.Services,
                UnitPrice = invoiceDbo.UnitPrice,
                Quantity = invoiceDbo.Quantity,
                CustomerName = invoiceDbo.CustomerName,
                Email = invoiceDbo.Email,
                Phone = invoiceDbo.Phone,
                Address = invoiceDbo.Address
            };

            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice == null)
            {
                return RedirectToAction("Index");
            }
            var invoiceDbo = new InvoiceDbo
            {
                Number = invoice.Number,
                status = invoice.status,
                IssueDate = invoice.IssueDate,
                DueDate = invoice.DueDate,
                Services = invoice.Services,
                UnitPrice = invoice.UnitPrice,
                Quantity = invoice.Quantity,
                CustomerName = invoice.CustomerName,
                Email = invoice.Email,
                Phone = invoice.Phone,
                Address = invoice.Address
            };

            ViewBag.InvoiceId = invoice.Id;
            return View(invoiceDbo);
        }
        [HttpPost]
        public IActionResult Edit(InvoiceDbo invoiceDbo, int id)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice == null)
            {
                return RedirectToAction("Index");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            invoice.Number = invoiceDbo.Number;
            invoice.status = invoiceDbo.status;
            invoice.IssueDate = invoiceDbo.IssueDate;
            invoice.DueDate = invoiceDbo.DueDate;
            invoice.Services = invoiceDbo.Services;
            invoice.UnitPrice = invoiceDbo.UnitPrice;
            invoice.Quantity = invoiceDbo.Quantity;
            invoice.CustomerName = invoiceDbo.CustomerName;
            invoice.Email = invoiceDbo.Email;
            invoice.Phone = invoiceDbo.Phone;
            invoice.Address = invoiceDbo.Address;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice == null)
            {
                return RedirectToAction("Index");
            }
            context.Invoices.Remove(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
