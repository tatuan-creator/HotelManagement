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

        public ActionResult Create()
        {
            ViewBag.paymentsStatus = data.PaymentsStatus.ToList();
            return View(new Payment());
        }

        [HttpPost]
        public ActionResult Create(Payment payment)
        {
            data.Payments.InsertOnSubmit(payment);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var item = data.Payments.FirstOrDefault(m => m.ID == id);
            ViewBag.paymentsStatus = data.PaymentsStatus.ToList();
            return View(item);
        }

        [HttpPost]
        public ActionResult Update(Payment payment)
        {
            var item = data.Payments.FirstOrDefault(m => m.ID == payment.ID);
            item.PaymentsName = payment.PaymentsName;
            item.PaymentS = payment.PaymentS;
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = data.Payments.FirstOrDefault(m => m.ID == id);
            item.PaymentS = 6;
            data.SubmitChanges();
            return RedirectToAction("Index", "Payments");
        }
    }
}