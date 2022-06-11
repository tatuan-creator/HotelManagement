using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Areas.Admin.Controllers
{
    public class TenancyController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Admin/Tenancy
        public ActionResult Index()
        {
            var listTenancy = data.Tenancies.ToList();
            return View(listTenancy);
        }

        public ActionResult Create()
        {
            ViewBag.room = data.Rooms.ToList();
            ViewBag.customer = data.Customers.ToList();
            ViewBag.tenancyStatus = data.TenancyStatus.ToList();
            return View(new Tenancy());
        }

        [HttpPost]
        public ActionResult Create(Tenancy tenancy)
        {
            tenancy.TenancyS = 1;
            data.Tenancies.InsertOnSubmit(tenancy);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}