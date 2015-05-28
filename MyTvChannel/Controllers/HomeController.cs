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
            List<MyChannelViewModel> model;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.myChannels.Where(x => x.DateDeleted == null).Select(x => new MyChannelViewModel()
                {
                    Id = x.Id,
                    DateDeleted = null,
                    imageUrl = x.imageUrl,
                    Name = x.Name,
                    myShows = x.myShows.Where(a => a.DateDeleted == null).ToList()
                }).ToList();
            }
            return View(model);
        }

        public ActionResult AddMyChannel()
        {
            return View(new MyChannel());
        }

        [HttpPost]
        public ActionResult AddMyChannel(MyChannel model)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.myChannels.Add(model);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult MyChannelDetails(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            MyChannel model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.myChannels.Include("myShows").FirstOrDefault(x => x.Id == id);
            }
            if (model == null) return RedirectToAction("Index");
            return View(model);
        }

        public ActionResult CreateMyShows(int? id)
        {
            if (id == null) return RedirectToAction("Index");
           MyShows model = new MyShows();
            model.MyChannelId = id.Value;
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateMyShows(MyShows model)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.myShows.Add(model);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMyChannel(int? id)
        {
            if (id != null)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    MyChannel model = db.myChannels.FirstOrDefault(x => x.Id == id);
                    model.DateDeleted = DateTime.Now;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult MyShowsDetails(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            MyShows model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.myShows.Include("MyChannel").FirstOrDefault(x => x.Id == id);
            }
            if (model == null || model.DateDeleted != null) return RedirectToAction("Index");
            return View(model);
        }

        public ActionResult DeleteMyShows(int? id)
        {
            if (id != null)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    MyShows model = db.myShows.FirstOrDefault(x => x.Id == id);
                    model.DateDeleted = DateTime.Now;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditMyChannel(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            MyChannel model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.myChannels.FirstOrDefault(x => x.Id == id);
            }
            return View("AddMyChannel", model);
        }
        [HttpPost]
        public ActionResult EditMyChannel(MyChannel model)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                   MyChannel dbMyChannel = db.myChannels.FirstOrDefault(x => x.Id == model.Id);
                    if (dbMyChannel != null)
                    {
                        dbMyChannel.Name = model.Name;
                        dbMyChannel.imageUrl = model.imageUrl;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditMyShows(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            MyShows model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.myShows.FirstOrDefault(x => x.Id == id);
            }
            if (model == null) return RedirectToAction("Index");
            return View("CreateMyShows", model);
        }

        [HttpPost]
        public ActionResult EditMyShows(MyShows model)
        {
            if (model.Id != null && ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    MyShows dbMyShows = db.myShows.FirstOrDefault(x => x.Id == model.Id);
                    if (dbMyShows != null)
                    {
                        dbMyShows.imageUrl = model.imageUrl;
                        dbMyShows.Title = model.Title;
                        dbMyShows.Price = model.Price;
                        dbMyShows.Category = model.Category;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
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