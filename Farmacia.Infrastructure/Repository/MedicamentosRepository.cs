using Farmacia.Application.Common.Interfaces;
using Farmacia.Domain.Entities;
using Farmacia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Infrastructure.Repository
{
    public class MedicamentosRepository : Repository<Medicamentos>, IMedicamentos
    {
        private readonly ApplicationDbContext _db;

        public MedicamentosRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Medicamentos entity)
        {
            _db.Update(entity);
        }
    }
}
