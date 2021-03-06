﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            // var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes

        };
            return View(viewModel);
        }

        [HttpPost]
        //public ActionResult Create(NewCustomerViewModel viewModel)
        public ActionResult Create(Customer customer)   
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerIdDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerIdDb.Name = customer.Name;
                customerIdDb.MembershiptypeId = customer.MembershiptypeId;
                customerIdDb.ISubscribedToNewsletter = customer.ISubscribedToNewsletter;
            }

          
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("New", viewModel);
        }

        private IEnumerable<Customer> GetCustomers ()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Johny Bravo" },
                new Customer {Id = 2, Name = "Mary Jane" }
            };
        }
    }
}