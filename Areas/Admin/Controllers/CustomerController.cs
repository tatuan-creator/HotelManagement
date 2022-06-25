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
            foreach(var item in listCustomer)
            {
                item.ID = item.ID.Trim();
            }    
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

        public ActionResult Update(string id)
        {
            var item = data.Customers.FirstOrDefault(m => m.ID.Equals(id));
            ViewBag.customerStatus = data.CustomerStatus.ToList();
            return View(item);
        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            var item = data.Customers.FirstOrDefault(m => m.ID.Equals(customer.ID));
            item.FullName = customer.FullName;
            item.email = customer.email;
            item.Phone = customer.Phone;
            item.CustomerS = customer.CustomerS;
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var item = data.Customers.FirstOrDefault(m => m.ID.Equals(id));
            item.CustomerS = 2;
            data.SubmitChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}