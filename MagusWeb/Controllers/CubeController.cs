using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagusWeb.Models;

namespace MagusWeb.Controllers
{
    public class CubeController : Controller
    {
        private MagusEntities db = new MagusEntities();

        // GET: Cube
        public ActionResult Index()
        {
            return View(db.Cube.ToList());
        }

        // GET: Cube/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cube cube = db.Cube.Find(id);
            if (cube == null)
            {
                return HttpNotFound();
            }
            return View(cube);
        }

        // GET: Cube/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cube/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,CubeValue")] Cube cube)
        {
            if (ModelState.IsValid)
            {
                db.Cube.Add(cube);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cube);
        }

        // GET: Cube/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cube cube = db.Cube.Find(id);
            if (cube == null)
            {
                return HttpNotFound();
            }
            return View(cube);
        }

        // POST: Cube/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,CubeValue")] Cube cube)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cube).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cube);
        }

        // GET: Cube/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cube cube = db.Cube.Find(id);
            if (cube == null)
            {
                return HttpNotFound();
            }
            return View(cube);
        }

        // POST: Cube/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cube cube = db.Cube.Find(id);
            db.Cube.Remove(cube);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
