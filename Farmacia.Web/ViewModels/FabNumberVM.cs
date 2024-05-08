using Farmacia.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Farmacia.Web.ViewModels
{
    public class FabNumberVM
    {
        public Fabricas Fabricas { get; set; } = null!;
        [ValidateNever]
        public IEnumerable<SelectListItem>? FabList { get; set; }
    }
}
