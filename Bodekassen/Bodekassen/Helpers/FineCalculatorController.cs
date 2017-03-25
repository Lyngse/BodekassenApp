using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bodekassen.Helpers
{
    public class FineCalculatorController : Controller
    {
        DB.BodekassenDBContainer db = new DB.BodekassenDBContainer();
        // GET: FineCalculator
        public ActionResult Index()
        {
            return Json(new { status = "success" });
        }


    }
}