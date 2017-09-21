using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Delivery.Models;



namespace Delivery.Controllers
{
    public class DeliveryDetailController : Controller
    {
        private WarehouseEntities db = new WarehouseEntities();
        private string _tab = "";
        // GET: DeliveryDetail
        public ActionResult Index(string Delivery, string tab)
        {
            if (String.IsNullOrEmpty(Delivery))
            {
                return RedirectToAction("Index", "DeliveryStatus");
            }
            if ( String.IsNullOrEmpty(tab))
            {
                tab = "0";
            }
            _tab = tab;
            ViewBag.Tab = _tab;
            System.Data.Entity.Core.Objects.ObjectParameter op = new System.Data.Entity.Core.Objects.ObjectParameter("deliveryfound", 0);
            System.Data.Entity.Core.Objects.ObjectResult<mvc_ExamineDelivery_Result> res = db.mvc_ExamineDelivery(Delivery,op);
            ViewBag.Delivery = Delivery;
            var xx = from a in db.mvc_ExamineDelivery(Delivery, op)
                     orderby Delivery
                     select a;

            return View(xx);
        }
    }
}