using Farmacia.Application.Common.Interfaces;
using Farmacia.Domain.Entities;
using Farmacia.Infrastructure.Data;
using Farmacia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Farmacia.Web.Controllers
{
    public class FabricaController : Controller
    {
        private readonly IUnityOfWork _unityOfWork;

        public FabricaController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public IActionResult Index()
        {
            var fabNumbers = _unityOfWork.Fabricas
                .GetAll(includeProperties: "Medicamentos");
            return View(fabNumbers);
        }

        public IActionResult Create()
        {
            FabNumberVM fabNumberVM = new FabNumberVM
            {
                FabList = _unityOfWork.Medicamentos.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            return View(fabNumberVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FabNumberVM obj)
        {
            bool medexists = _unityOfWork.Fabricas.Any(u => u.Id == obj.Fabricas_Number.Id);
            if (ModelState.IsValid && !medexists)
            {
                _unityOfWork.Fabricas.Add(obj.Fabricas_Number);
                _unityOfWork.Save();
                TempData["success"] = "The fabric has been created successfully";
                return RedirectToAction(nameof(Index));
            }
            if (medexists)
            {
                TempData["error"] = "The Medicine Number already exists";
            }
            obj.FabList = _unityOfWork.Medicamentos.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }




        public IActionResult Update(int farmId)
        {
            FabNumberVM fabNumberVM = new FabNumberVM
            {
                FabList = _unityOfWork.Medicamentos.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Fabricas_Number= _unityOfWork.Fabricas.Get(_=> _.Id == farmId)
                
            };
            if(fabNumberVM.Fabricas_Number is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(fabNumberVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Fabricas obj)
        {
            if(ModelState.IsValid)
            {
                _unityOfWork.Fabricas.Update(obj);
                _unityOfWork.Save();
                TempData["success"] = "The Fabric has been updated sucessfull";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The Fabric has been not updated sucessfull";
            return View(obj);
        }
        public IActionResult Delete(int farmId)
        {
            FabNumberVM fabNumberVM = new()
            {
                FabList = _unityOfWork.Medicamentos.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Fabricas_Number = _unityOfWork.Fabricas.Get(_ => _.Id == farmId)
            };

            if (fabNumberVM.Fabricas_Number is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(fabNumberVM);
        }
        [HttpPost]
        public IActionResult Delete(FabNumberVM fabNumberVM)
        {
            Fabricas? objFromDb = _unityOfWork.Fabricas.Get(_=> _.Id == fabNumberVM.Fabricas_Number.Id);
            if (objFromDb is not null)
            {
                _unityOfWork.Fabricas.Remove(objFromDb);
                _unityOfWork.Save();
                TempData["success"] = "The Fabric number has been deleted successfully.";

                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The fabric  could not be deleted.";
            return View(fabNumberVM);
        }
    }
}
