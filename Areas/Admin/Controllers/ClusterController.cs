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
            var item = data.Clusters.FirstOrDefault(m => m.ID == id);
            ViewBag.clusterStatus = data.ClusterStatus.ToList();
            return View(item);
        }

        [HttpPost]
        public ActionResult Update(Cluster cluster)
        {
            var item = data.Clusters.FirstOrDefault(m => m.ID == cluster.ID);
            item.AddressCluster = cluster.AddressCluster;
            item.ManagementEmail = cluster.ManagementEmail;
            item.ManagementPhone = cluster.ManagementPhone;
            item.ManagementName = cluster.ManagementName;
            item.ClusterS = cluster.ClusterS;
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = data.Clusters.FirstOrDefault(m => m.ID == id);
            item.ClusterS = 2;
            data.SubmitChanges();
            return RedirectToAction("Index", "Cluster");
        }
    }
}