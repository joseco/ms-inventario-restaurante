using Inventario.Domain.Models.Transacciones;
using Inventario.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.EF.Repository
{
    internal class TransaccionRepository : ITransaccionRepository
    {
        public Task CreateAsync(Transaccion obj)
        {
            throw new NotImplementedException();
        }

        public Task<Transaccion> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Transaccion obj)
        {
            throw new NotImplementedException();
        }
    }
}
