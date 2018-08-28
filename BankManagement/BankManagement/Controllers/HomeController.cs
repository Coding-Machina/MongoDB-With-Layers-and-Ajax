using BM.BF;
using BM.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankManagement.Controllers
{
    public class HomeController : Controller
    {
        BankService bnkservice = new BankService();
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult Get()
        {
            return Json(bnkservice.Get(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Post(Bank bank)
        {
            return Json(bnkservice.Post(bank), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TransactionPost(string id, Transaction schedule)
        {
            return Json(bnkservice.TransInsert(id, schedule), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TransactionGet(string id)
        {
            return Json(bnkservice.TransGet(id),JsonRequestBehavior.AllowGet);
        }

    }
}