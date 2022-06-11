using HotelManagement.Models;
using HotelManagement.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Admin/Customer
        public ActionResult Index()
        {
            var listCustomer = data.Customers.ToList();
            return View(listCustomer);
        }

        public ActionResult Create()
        {
            ViewBag.customerStatus = data.CustomerStatus.ToList();
            return View(new Customer());
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            customer.Password = Password.Encrypt(customer.Password);
            data.Customers.InsertOnSubmit(customer);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}