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

        public ActionResult Detail(int id)
        {
            var roomDetail = data.Rooms.FirstOrDefault(m => m.IDRoom == id);
            return View(roomDetail);
        }

        public ActionResult Create()
        {
            ViewBag.roomType = data.RoomTypes.ToList();
            ViewBag.cluster = data.Clusters.ToList();
            ViewBag.roomStatus = data.RoomStatus.ToList();
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
            var item = data.Rooms.FirstOrDefault(m => m.IDRoom == id);
            ViewBag.roomType = data.RoomTypes.ToList();
            ViewBag.cluster = data.Clusters.ToList();
            ViewBag.roomStatus = data.RoomStatus.ToList();
            return View(item);
        }

        [HttpPost]
        public ActionResult Update(Room room)
        {
            var item = data.Rooms.FirstOrDefault(m => m.IDRoom == room.IDRoom);
            item.RoomName = room.RoomName;
            item.StatusR = room.StatusR;
            item.RoomType_ID = room.RoomType_ID;
            item.Cluster_ID = room.Cluster_ID;
            item.Amount = room.Amount;
            item.Area = room.Area;
            item.Price = room.Price;
            item.Describe = room.Describe;
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = data.Rooms.FirstOrDefault(m => m.IDRoom == id);
            item.StatusR = 0;
            data.SubmitChanges();
            return RedirectToAction("Index", "Room");
        }
    }
}