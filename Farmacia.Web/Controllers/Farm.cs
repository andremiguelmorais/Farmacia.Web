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
    }
}
