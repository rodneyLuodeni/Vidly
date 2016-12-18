using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Rodney"},
                new Customer { Id = 2, Name = "Effie"}
            };

            var viewModel = new CustomerViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }


        //GET: Details
        public ActionResult Details(int id)
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Rodney"},
                new Customer { Id = 2, Name = "Effie"}
            };

            if (id == 0 || id > customers.Count)
            {
                  return RedirectToAction("Index");
            }

      

            var result = customers[(id -1)];

            return View(result);

        }



    }
}