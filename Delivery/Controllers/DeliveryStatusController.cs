using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Delivery.Models;

namespace Delivery.Controllers
{
    public class DeliveryStatusController : Controller
    {
        private WarehouseEntities db = new WarehouseEntities();
        private static string _tab = "0";
        // GET: DeliveryStatus
        public ActionResult Index(string tab)
        {
            if ( String.IsNullOrEmpty(tab))
            {
                tab = "1";
            }
            _tab = tab;
            System.Data.Entity.Core.Objects.ObjectResult<mvc_DeliveryStatusSummary_Result> res = db.mvc_DeliveryStatusSummary();

            System.Data.Entity.Core.Objects.ObjectResult<mvc_getDeliverySummary_Result> sum = db.mvc_getDeliverySummary();
            List<mvc_getDeliverySummary_Result> reslist = db.mvc_getDeliverySummary().ToList();
            ViewBag.StatusNotStarted = 0;
            ViewBag.StatusInProgress = 0;
            ViewBag.StatusComplete = 0;
            ViewBag.StatusAwaitRework = 0;
            ViewBag.Tab = _tab;

            foreach ( mvc_getDeliverySummary_Result re in reslist)
            {
                if (re.Status.Substring(0, 1) == "0")
                    ViewBag.StatusComplete = re.Count;
                if (re.Status.Substring(0, 1) == "1")
                    ViewBag.StatusInProgress = re.Count;
                if (re.Status.Substring(0, 1) == "2")
                    ViewBag.StatusNotStarted = re.Count;
                if (re.Status.Substring(0, 1) == "3")
                    ViewBag.StatusAwaitRework = re.Count;
                if (re.Status.Substring(0, 1) == tab)
                    ViewBag.DStatus = re.Status.Substring(2);
            }
            
            var xx = from a in db.mvc_DeliveryStatusSummary()
                     where a.DStatus.Substring(0,1) == tab
                     select a;

            return View(xx);
            
        }

        public ActionResult Search(FormCollection fc)
        {
            if ( fc.Count == 0 )
            {
                return RedirectToAction("Index", "DeliveryStatus");
            }

        
            //  @Html.ActionLink(item.Delivery, "Index", "DeliveryDetail", new { delivery = item.Delivery }, null)
            return RedirectToAction("Index", "DeliveryDetail", new { Delivery = fc["delivery"] });

        }

    }
}