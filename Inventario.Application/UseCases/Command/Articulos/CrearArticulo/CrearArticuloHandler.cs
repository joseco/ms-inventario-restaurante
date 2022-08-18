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

        public CrearArticuloHandler(IArticuloRepository articuloRepository, IUnitOfWork unitOfWork)
        {
            this.articuloRepository = articuloRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearArticuloCommand request, CancellationToken cancellationToken)
        {
            var articulo = new Articulo(request.NombreArticulo);

            await articuloRepository.CreateAsync(articulo);

            await unitOfWork.Commit();

            return articulo.Id;
        }
    }
}
