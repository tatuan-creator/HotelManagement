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
            ViewBag.room = data.Rooms.Where(m => m.RoomStatus.StatusName.Equals("Còn trống")).ToList();
            ViewBag.customer = data.Customers.Where(m => m.CustomerStatus.StatusName.Equals("Hoạt động")).ToList();
            ViewBag.tenancyStatus = data.TenancyStatus.ToList();
            return View(new Tenancy());
        }

        [HttpPost]
        public ActionResult Create(Tenancy tenancy)
        {
            tenancy.TenancyS = 1;
            var roomChange = data.Rooms.FirstOrDefault(m => m.IDRoom == tenancy.TenancyRoom);
            roomChange.StatusR = 0;
            data.Tenancies.InsertOnSubmit(tenancy);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var item = data.Tenancies.FirstOrDefault(m => m.ID == id);
            ViewBag.room = data.Rooms.Where(m => m.RoomStatus.StatusName.Equals("Còn trống")).ToList();
            ViewBag.customer = data.Customers.Where(m => m.CustomerStatus.StatusName.Equals("Hoạt động")).ToList();
            if (item.TenancyStatus.IDStatus == 2)
            {
                ViewBag.tenancyStatus = data.TenancyStatus.Where(m => m.StatusName.Equals("Đã hết hạn"));
            }
            else
            {
                ViewBag.tenancyStatus = data.TenancyStatus.ToList();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Update(Tenancy tenancy)
        {
            var item = data.Tenancies.FirstOrDefault(m => m.ID == tenancy.ID);
            item.TenancyDate = tenancy.TenancyDate;
            item.TimeStart = tenancy.TimeStart;
            item.TimeEnd = tenancy.TimeEnd;
            item.Deposit = tenancy.Deposit;
            item.TenancyS = tenancy.TenancyS;
            if(tenancy.TenancyStatus.IDStatus == 2)
            {
                var roomChange = data.Rooms.FirstOrDefault(m => m.IDRoom == item.Room.IDRoom);
                roomChange.StatusR = 1;
            }    
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = data.Tenancies.FirstOrDefault(m => m.ID == id);
            item.TenancyS = 2;
            data.SubmitChanges();
            return RedirectToAction("Index", "Tenancy");
        }
    }
}