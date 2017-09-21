using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Delivery.Models;

namespace Delivery.Controllers
{
    public class WIPController : Controller
    {
        private WarehouseEntities db = new WarehouseEntities();
        private static string _catno = "";
        private static string _optno = "";
        private static string _delivery = "";
        private static string _supplier = "";
        private static string _tab = "";
        // GET: WIP
        public ActionResult Find(string Delivery,string Supplier,string CatNo, string OptNo , string tab )
        {
            if (String.IsNullOrEmpty(Delivery))
            {
                return RedirectToAction("Index", "DeliveryStatus");
            }
            _tab = tab;
            _delivery = Delivery;
            _catno = CatNo;
            _supplier = Supplier;
            _optno = OptNo ;

            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(_optno) )
            {
                return RedirectToAction("Index", "DeliveryStatus");
            }
            ViewBag.Supplier = _supplier;
            ViewBag.CatNo = _catno;
            ViewBag.OptNo = _optno;
            ViewBag.Delivery = _delivery;
            ViewBag.Tab = _tab;
            System.Data.Entity.Core.Objects.ObjectResult<mvc_showWipForItem_Result> res = db.mvc_showWipForItem(_delivery ,_catno, _optno,_supplier);
            return View(res);
        }
    }
}