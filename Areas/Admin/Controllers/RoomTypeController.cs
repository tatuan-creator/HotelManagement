using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Areas.Admin.Controllers
{
    public class RoomTypeController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Admin/RoomType
        public ActionResult Index()
        {
            List<RoomType> listRoomType = data.RoomTypes.ToList();
            return View(listRoomType);
        }

        public ActionResult Create()
        {
            ViewBag.roomTypeStatus = data.StatusRoomTypes.ToList();
            return View(new RoomType());
        }

        [HttpPost]
        public ActionResult Create(RoomType roomType)
        {
            List<RoomType> listRoomType = data.RoomTypes.ToList();
            data.RoomTypes.InsertOnSubmit(roomType);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var item = data.RoomTypes.FirstOrDefault(m => m.IDRoomType == id);
            ViewBag.roomTypeStatus = data.StatusRoomTypes.ToList();
            return View(item);
        }

        [HttpPost]
        public ActionResult Update(RoomType roomType)
        {
            var item = data.RoomTypes.FirstOrDefault(m => m.IDRoomType == roomType.IDRoomType);
            item.RoomTypeName = roomType.RoomTypeName;
            item.StatusRT = roomType.StatusRT;
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = data.RoomTypes.FirstOrDefault(m => m.IDRoomType == id);
            item.StatusRT = 0;
            data.SubmitChanges();
            return RedirectToAction("Index", "RoomType");
        }
    }
}