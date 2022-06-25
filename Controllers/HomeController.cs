using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Security;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            if (Session["KhachHang"] == null)
            {
                return View(new Customer());
            }
            return Redirect("~/CustomerAdmin/Index");
        }

        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            customer.Password = Password.Encrypt(customer.Password);
            var loginCustomer = data.Customers.FirstOrDefault(m => m.ID == customer.ID);
            if (loginCustomer != null)
            {
                if (customer.ID == loginCustomer.ID.Trim() && loginCustomer.Password.Trim() == customer.Password)
                {
                    Session["KhachHang"] = loginCustomer;
                    return Redirect("~/CustomerAdmin/Index");
                }
                else
                {
                    ViewBag.ThongBao = "Thông tin tài khoản sai";
                }
            }
            else
            {
                ViewBag.ThongBao = "Tài khoản không tồn tại";
            }
            return View(new Customer());
        }
    }
}