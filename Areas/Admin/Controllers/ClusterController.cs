using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Areas.Admin.Controllers
{
    public class ClusterController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Admin/Cluster
        public ActionResult Index()
        {
            List<Cluster> listCluster = data.Clusters.ToList();
            return View(listCluster);
        }

        public ActionResult Create()
        {
            ViewBag.ClusterStatus = data.ClusterStatus.ToList();
            return View(new Cluster());
        }

        [HttpPost]
        public ActionResult Create(Cluster cluster)
        {
            List<Cluster> listCluster = data.Clusters.ToList();
            data.Clusters.InsertOnSubmit(cluster);
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