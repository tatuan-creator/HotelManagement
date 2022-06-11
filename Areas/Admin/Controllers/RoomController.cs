using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Areas.Admin.Controllers
{
    public class RoomController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Admin/Room
        public ActionResult Index()
        {
            var listRoom = data.Rooms.ToList();
            return View(listRoom);
        }

        public ActionResult Create()
        {
            ViewBag.roomType = data.RoomTypes.ToList();
            ViewBag.cluster = data.Clusters.ToList();
            ViewBag.status = data.RoomStatus.ToList();
            return View(new Room());
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            List<RoomType> listRoomType = data.RoomTypes.ToList();
            data.Rooms.InsertOnSubmit(room);
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