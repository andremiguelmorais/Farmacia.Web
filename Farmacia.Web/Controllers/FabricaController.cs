using Farmacia.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

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
            var farm=_db.Fabricas.ToList();
            return View(farm);
        }
    }
}
