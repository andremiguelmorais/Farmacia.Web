using Farmacia.Infrastructure.Data;
using Farmacia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Farmacia.Web.Controllers
{
    public class FabricaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FabricaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var fabNumbers = _db.Fabricas
                .Include(u=>u.Medicamentos)
                .ToList();
            return View(fabNumbers);
        }
        //GET
        public IActionResult Create()
        {
            FabNumberVM fabNumberVM = new FabNumberVM()
            {
                FabList = _db.Medicamentos.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            
            return View(fabNumberVM);
        }
    }
}
