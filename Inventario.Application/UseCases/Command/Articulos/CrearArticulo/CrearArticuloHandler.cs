using Inventario.Domain.Factories;
using Inventario.Domain.Models.Articulos;
using Inventario.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Application.UseCases.Command.Articulos.CrearArticulo
{
    public class CrearArticuloHandler : IRequestHandler<CrearArticuloCommand, Guid>
    {
        private readonly IArticuloRepository articuloRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IArticuloFactory articuloFactory;

        public CrearArticuloHandler(IArticuloRepository articuloRepository, IUnitOfWork unitOfWork, IArticuloFactory articuloFactory)
        {
            this.articuloRepository = articuloRepository;
            this.unitOfWork = unitOfWork;
            this.articuloFactory = articuloFactory;
        }

        public async Task<Guid> Handle(CrearArticuloCommand request, CancellationToken cancellationToken)
        {
            var articulo = articuloFactory.Create(request.NombreArticulo, request.PrecioVenta);

            await articuloRepository.CreateAsync(articulo);

            await unitOfWork.Commit();

            return articulo.Id;
        }
    }
}
