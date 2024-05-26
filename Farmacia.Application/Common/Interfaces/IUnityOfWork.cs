using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.Common.Interfaces
{
    public interface IUnityOfWork
    {
        IMedicamentos Medicamentos { get; }
        IFabricas Fabricas { get; }
        void Save();
    }
}
