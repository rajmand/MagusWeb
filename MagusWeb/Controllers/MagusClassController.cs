using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MagusWeb.Models;

namespace MagusWeb.Controllers
{
    public class MagusClassController : Controller
    {
        private MagusEntities db = new MagusEntities();

        // GET: MagusClass
        public ActionResult Index()
        {
            var magusClass = db.MagusClass.Include(m => m.Cube).Include(m => m.Psi1);
            return View(magusClass.ToList());
        }

        // GET: MagusClass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MagusClass magusClass = db.MagusClass.Find(id);
            if (magusClass == null)
            {
                return HttpNotFound();
            }
            return View(magusClass);
        }

        // GET: MagusClass/Create
        public ActionResult Create()
        {
            ViewBag.PainPerLevelCube = new SelectList(db.Cube, "id", "id");
            ViewBag.Psi = new SelectList(db.Psi, "id", "Name");
            return View();
        }

        // POST: MagusClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,InitiatingBasic,OffensiveBasic,OffensiveMinPerLevel,DefensiveBasic,DefensiveMinPerLevel,TargetingBasic,FighterModPerLevel,HealthBasic,PainBasic,PainPerLevelNumber,PainPerLevelCube,QualificationBasic,QualificationPerLevel,PercentagePerLevel,Psi,ClimbBasic,FallingBasic,JumpBasic,SneakingBasic,StealthBasic,TightropeBasic,PickpocketBasic,ExploreTrapBasic,ShutterBasic,SecureDoorSearchBasic")] MagusClass magusClass)
        {
            if (ModelState.IsValid)
            {
                db.MagusClass.Add(magusClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PainPerLevelCube = new SelectList(db.Cube, "id", "id", magusClass.PainPerLevelCube);
            ViewBag.Psi = new SelectList(db.Psi, "id", "Name", magusClass.Psi);
            return View(magusClass);
        }

        // GET: MagusClass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MagusClass magusClass = db.MagusClass.Find(id);
            if (magusClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.PainPerLevelCube = new SelectList(db.Cube, "id", "id", magusClass.PainPerLevelCube);
            ViewBag.Psi = new SelectList(db.Psi, "id", "Name", magusClass.Psi);
            return View(magusClass);
        }

        // POST: MagusClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,InitiatingBasic,OffensiveBasic,OffensiveMinPerLevel,DefensiveBasic,DefensiveMinPerLevel,TargetingBasic,FighterModPerLevel,HealthBasic,PainBasic,PainPerLevelNumber,PainPerLevelCube,QualificationBasic,QualificationPerLevel,PercentagePerLevel,Psi,ClimbBasic,FallingBasic,JumpBasic,SneakingBasic,StealthBasic,TightropeBasic,PickpocketBasic,ExploreTrapBasic,ShutterBasic,SecureDoorSearchBasic")] MagusClass magusClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(magusClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PainPerLevelCube = new SelectList(db.Cube, "id", "id", magusClass.PainPerLevelCube);
            ViewBag.Psi = new SelectList(db.Psi, "id", "Name", magusClass.Psi);
            return View(magusClass);
        }

        // GET: MagusClass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MagusClass magusClass = db.MagusClass.Find(id);
            if (magusClass == null)
            {
                return HttpNotFound();
            }
            return View(magusClass);
        }

        // POST: MagusClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MagusClass magusClass = db.MagusClass.Find(id);
            db.MagusClass.Remove(magusClass);
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
