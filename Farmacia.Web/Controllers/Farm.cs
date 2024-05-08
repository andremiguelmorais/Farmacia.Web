    using Farmacia.Domain.Entities;
using Farmacia.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia.Web.Controllers
{
    public class Farm : Controller
    {
        private readonly ApplicationDbContext _db;

        public Farm(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var farm=_db.Medicamentos.ToList();
            return View(farm);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medicamentos FarmId)
        {
            if(ModelState.IsValid)
            {
                _db.Medicamentos.Add(FarmId);
                TempData["success"] = "The medicine has been created sucessfull";

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The medicine has been not created sucessfull";

            return View(FarmId);
        }
        public IActionResult Update(int farmId)
        {
            Medicamentos? obj= _db.Medicamentos.FirstOrDefault(x=>x.Id == farmId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Medicamentos obj)
        {
            if (ModelState.IsValid)
            {
                _db.Medicamentos.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "The medicine has been updatesd sucessfull";

                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The medicine has been not updated sucessfull";

            return View(obj);
        }
        public IActionResult Delete(int farmId)
        {
            Medicamentos? obj= _db.Medicamentos.FirstOrDefault(x => x.Id == farmId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }
        //POST
        [HttpPost]
        public IActionResult Delete(Medicamentos obj)
        {
            Medicamentos? objFromDb= _db.Medicamentos.FirstOrDefault(_=>_.Id == obj.Id);
            if(objFromDb is not null)
            {
                _db.Medicamentos.Remove(objFromDb);
                TempData["success"] = "The medicine has been deleted sucessfull";

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The medicine has been not deleted sucessfull";

            return View(obj);
        }
    }
}
