using Farmacia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.Common.Interfaces
{
    public interface IFabricas: IRepository<Fabricas>
    {
        void Update(Fabricas entity);
    }
}
