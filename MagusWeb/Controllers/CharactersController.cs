using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MagusWeb.Models;
using MagusWeb.Services;

namespace MagusWeb.Controllers
{
    public class CharactersController : Controller
    {
        private readonly MagusEntities _db = new MagusEntities();
        private readonly ICharacterValueService _characterValueService;
        private readonly IPsiService _psiService;

        public CharactersController(ICharacterValueService characterValueService, IPsiService psiService)
        {
            _characterValueService = characterValueService;
            _psiService = psiService;
        }

        // GET: Characters
        public ActionResult Index()
        {
            var character = _db.Character.Include(c => c.Psi1).Include(c => c.Species);
            return View(character.ToList());
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _db.Character.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.Psi = _psiService.GetPsi();// new SelectList(_db.Psi, "id", "Name");
            ViewBag.Specie = new SelectList(_db.Species, "id", "Name");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Strength,Stanima,Agility,Dexterity,Health,Beauty,Intelligence,Astral,WillPower,Detection,Name,Class,Level,Personality,Religion,Homeland,School,Age,Height,Weight,Vitality,Pain,Specie,Psi")] Character character)
        {
            if (ModelState.IsValid)
            {
                _db.Character.Add(character);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Psi = new SelectList(_db.Psi, "id", "Name", character.Psi);
            ViewBag.Specie = new SelectList(_db.Species, "id", "Name", character.Specie);
            return View(character);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _db.Character.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.Psi = new SelectList(_db.Psi, "id", "Name", character.Psi);
            ViewBag.Specie = new SelectList(_db.Species, "id", "Name", character.Specie);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Strength,Stanima,Agility,Dexterity,Health,Beauty,Intelligence,Astral,WillPower,Detection,Name,Class,Level,Personality,Religion,Homeland,School,Age,Height,Weight,Vitality,Pain,Specie,Psi")] Character character)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(character).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Psi = new SelectList(_db.Psi, "id", "Name", character.Psi);
            ViewBag.Specie = new SelectList(_db.Species, "id", "Name", character.Specie);
            return View(character);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _db.Character.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Character character = _db.Character.Find(id);
            _db.Character.Remove(character);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public JsonResult GetCharachterValues(int specie, int? strength, int? stamina, int? agility, int? dexterity, int? health, int? beauty, int? intelligence, int? astral, int? willPower, int? detection)
        {
            var data = _characterValueService.GetCharacterValues(specie, strength, stamina, agility, dexterity, health, beauty, intelligence, astral, willPower, detection);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPsiForLevel(int? psiType, int? level, int? intelligence)
        {
            var psi = _psiService.GetPsiForLevel(psiType, level, intelligence);
            return Json(psi, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPsiResistence(int? astral, int? willPower,
            int? astralStaticResistence, int? astralDynamicResistence, int? astralOther,
            int? mentalStaticResistence, int? mentalDynamicResistence, int? mentalOther)
        {
            var psiResisntence = new
            {
                AstralResistence = _psiService.GetAstralResistence(astral, astralStaticResistence, astralDynamicResistence, astralOther),
                MentalResistence = _psiService.GetMentalResistence(willPower, mentalStaticResistence, mentalDynamicResistence, mentalOther)
            };
            return Json(psiResisntence, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
