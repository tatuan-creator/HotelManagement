using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Areas.Admin.Controllers
{
    public class BillController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Admin/Bill
        public ActionResult Index()
        {
            var listBill = data.Bills.ToList();
            return View(listBill);
        }

        public ActionResult Create(int id)
        {
            var bill = new Bill();
            var billTenancy = data.Tenancies.FirstOrDefault(m => m.ID == id);
            bill.Tenancy = billTenancy;
            bill.TenancyRoom = id;
            bill.Total = 0;
            bill.RoomCharge = 0;
            return View(bill);
        }

        [HttpPost]
        public ActionResult Create(Bill bill)
        {
            var billTenancy = data.Tenancies.FirstOrDefault(m => m.ID == bill.TenancyRoom);
            bill.Tenancy = billTenancy;
            bill.Total = (bill.EndPower - bill.InitPower) * bill.PowerUnitPrice;
            bill.Total = (bill.EndWater - bill.InitWater) * bill.WaterUnitPrice;
            bill.Total = bill.Total + bill.Surcharge + bill.Tenancy.Room.Price;
            bill.BillS = 2;
            data.Bills.InsertOnSubmit(bill);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Update(int id)
        {
            var bill = data.Bills.FirstOrDefault(m => m.ID == id);
            return View(bill);
        }

        [HttpPost]
        public ActionResult Update(Bill bill)
        {
            var item = data.Bills.FirstOrDefault(m => m.ID == bill.ID);

            item.BillDate = bill.BillDate;
            item.InitPower = bill.InitPower;
            item.EndPower = bill.EndPower;
            item.PowerUnitPrice = bill.PowerUnitPrice;
            item.InitWater = bill.InitWater;
            item.EndWater = bill.EndWater;
            item.WaterUnitPrice = bill.WaterUnitPrice;
            item.Surcharge = bill.Surcharge;
            item.Total = 0;
            item.Total = (item.EndPower - item.InitPower) * item.PowerUnitPrice;
            item.Total = (item.EndWater - item.InitWater) * item.WaterUnitPrice;
            item.Total = item.Total + item.Surcharge + item.Tenancy.Room.Price;
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = data.Bills.FirstOrDefault(m => m.ID == id);
            item.BillS = 3;
            data.SubmitChanges();
            return RedirectToAction("Index", "Bill");
        }

        public ActionResult PaySuccess(int id)
        {
            var item = data.Bills.FirstOrDefault(m => m.ID == id);
            item.BillS = 1;
            data.SubmitChanges();
            return RedirectToAction("Index", "Bill");
        }
    }
}