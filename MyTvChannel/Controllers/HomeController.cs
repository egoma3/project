using MyTvChannel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTvChannel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<MyChannel> model;

            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.myChannels.Include("myShows").ToList();
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}