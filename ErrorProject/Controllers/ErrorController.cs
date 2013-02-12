using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ErrorProject.Models;

namespace ErrorProject.Controllers
{
    public class ErrorController : Controller
    {
        private ErrorDBEntities db = new ErrorDBEntities();

        //
        // GET: /Error/

        public ActionResult Index()
        {
            return View(db.Errors.ToList());
        }

        //
        // GET: /Error/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Error/Create

        [HttpPost]
        public ActionResult Create(Error error)
        {
            if (ModelState.IsValid && error.Name != null)
            {
                db.Errors.Add(error);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(error);
        }

        //
        // GET: /Error/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Error error = db.Errors.Find(id);
            if (error == null)
            {
                return HttpNotFound();
            }

            //Otsin LINQ-ga kõik kommentaarid, mis antud Erroril on
            var query = from x in db.Comments
                        where x.ErrorID == id
                        select x;

            ViewBag.Comments = query.ToList();

            return View(error);
        }

        //
        // POST: /Error/Edit/5

        [HttpPost]
        public ActionResult Edit(Error error)
        {
            if (ModelState.IsValid)
            {
                db.Entry(error).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(error);
        }

        //
        //GET: /Error/AddComment/5

        public ActionResult AddComment(int id = 0)
        {
            Comment comment = new Comment();
            comment.ErrorID = id;
            return View(comment);
        }

        //
        //POST: /Error/AddComment/5

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            if (ModelState.IsValid && comment.Text != null)
            {
                db.Comments.Add(comment);
                db.SaveChanges();

                //Redirectin tagasi errori editimise lehele
                return RedirectToAction("Edit/" + comment.ErrorID);
            }

            return View(comment);
        }

        //
        // GET: /Error/Search

        public ActionResult Search()
        {
                return View();
        }

        //
        //POST: /Error/Search/5
        [HttpPost]
        public ActionResult Search(int id = 0)
        {
            Error error = db.Errors.Find(id);

            return View(error);
        }
    }
}