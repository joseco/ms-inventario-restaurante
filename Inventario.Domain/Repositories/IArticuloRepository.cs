using Inventario.Domain.Models.Articulos;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Repositories
{
    public interface IArticuloRepository : IRepository<Articulo, Guid>
    {
        Task UpdateAsync(Articulo obj);
    }
}
