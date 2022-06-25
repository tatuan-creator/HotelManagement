using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class CustomerAdminController : Controller
    {
        // GET: Customer
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            var kh = Session["KhachHang"] as Customer;
            return View(kh);
        }

        public ActionResult Information()
        {
            var kh = Session["KhachHang"] as Customer;
            return View(kh);
        }
    }
}