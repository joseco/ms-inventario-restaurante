using Inventario.Domain.Models.Transacciones;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Repositories
{
    public interface ITransaccionRepository : IRepository<Transaccion, Guid>
    {
        Task UpdateAsync(Transaccion obj);
    }
}
