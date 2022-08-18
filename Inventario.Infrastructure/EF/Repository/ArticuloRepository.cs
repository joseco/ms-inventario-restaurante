using Inventario.Domain.Models.Articulos;
using Inventario.Domain.Repositories;
using Inventario.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.EF.Repository
{
    public class ArticuloRepository : IArticuloRepository
    {
        public readonly DbSet<Articulo> _articulos;

        public ArticuloRepository(WriteDbContext context)
        {
            _articulos = context.Articulo;
        }
        public async Task CreateAsync(Articulo obj)
        {
            await _articulos.AddAsync(obj);
        }

        public async Task<Articulo> FindByIdAsync(Guid id)
        {
            return await _articulos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Articulo obj)
        {
            _articulos.Update(obj);
            return Task.CompletedTask;
        }
    }
}
