using Farmacia.Application.Common.Interfaces;
using Farmacia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Infrastructure.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext _db;
        public IMedicamentos Medicamentos { get; private set; }

        public IFabricas Fabricas { get; private set; }
        public UnityOfWork (ApplicationDbContext db){
            _db = db;
            Medicamentos = new MedicamentosRepository(db);
            Fabricas = new FabricasRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
