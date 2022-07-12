using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo2.Controllers
{
    public class SampleController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string[] texts = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/Sample.txt"));
            ViewBag.Data = texts;
            return View();
        }
    }
}