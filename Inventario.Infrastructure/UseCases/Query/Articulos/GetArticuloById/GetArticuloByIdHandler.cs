using Inventario.Application.Dto;
using Inventario.Application.UseCases.Query.Articulos.GetArticuloById;
using Inventario.Infrastructure.EF.Contexts;
using Inventario.Infrastructure.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.UseCases.Query.Articulos.GetArticuloById
{
    public class GetArticuloByIdHandler : IRequestHandler<GetArticuloByIdQuery, ArticuloDto>
    {
        private readonly DbSet<ArticuloReadModel> _articuloDbSet;

        public GetArticuloByIdHandler(ReadDbContext context)
        {
            _articuloDbSet = context.Articulo;
        }

        public async Task<ArticuloDto> Handle(GetArticuloByIdQuery request, CancellationToken cancellationToken)
        {
            ArticuloReadModel model = await _articuloDbSet.FirstOrDefaultAsync(x => x.Id == request.Id);
            
            if(model == null)
            {
                return null;
            }


            return new ArticuloDto()
            {
                Id = model.Id,
                CostoPromedio = model.CostoPromedio,
                Nombre = model.Nombre,
                Stock = model.Stock
            };
        }
    }
}
