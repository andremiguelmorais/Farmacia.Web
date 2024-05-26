using Farmacia.Application.Common.Interfaces;
using Farmacia.Domain.Entities;
using Farmacia.Infrastructure.Data;
using Farmacia.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia.Web.Controllers
{
    public class Farm : Controller
    {
        private readonly IUnityOfWork _unityOfWork;

        public Farm(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public IActionResult Index()
        {
            var farm=_unityOfWork.Medicamentos.GetAll();
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
                _unityOfWork.Medicamentos.Add(FarmId);
                TempData["success"] = "The medicine has been created sucessfull";

                _unityOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(FarmId);
        }
        public IActionResult Update(int farmId)
        {
            Medicamentos? obj= _unityOfWork.Medicamentos.Get(x=>x.Id == farmId);
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
                _unityOfWork.Medicamentos.Update(obj);
                _unityOfWork.Save();
                TempData["success"] = "The medicine has been updatesd sucessfull";

                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The medicine has been not updated sucessfull";

            return View(obj);
        }
        public IActionResult Delete(int farmId)
        {
            Medicamentos? obj= _unityOfWork.Medicamentos.Get(x => x.Id == farmId);
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
            Medicamentos? objFromDb= _unityOfWork.Medicamentos.Get(_=>_.Id == obj.Id);
            if(objFromDb is not null)
            {
                _unityOfWork.Medicamentos.Remove(objFromDb);
                TempData["success"] = "The medicine has been deleted sucessfull";

                _unityOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The medicine has been not deleted sucessfull";

            return View(obj);
        }
    }
}
