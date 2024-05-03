using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Domain.Entities
{
    public class Fabricas
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Medicamentos")]
        public int Medicamentos_Id { get; set; }
        
        public Medicamentos Medicamentos { get; set; } = null!;
        [ValidateNever]
        public string Local { get; set; }
    }
}
