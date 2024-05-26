using Farmacia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.Common.Interfaces
{
    public interface IMedicamentos:IRepository<Medicamentos>
    {
        void Add(Medicamentos entity);
        void Update(Medicamentos entity);
    }
}
