using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Areas.Admin.Controllers
{
    public class PaymentsController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Admin/Payments
        public ActionResult Index()
        {
            var listPayments = data.Payments.ToList();
            return View(listPayments);
        }
    }
}