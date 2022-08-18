using Inventario.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Application.UseCases.Query.Articulos.GetArticuloById
{
    public class GetArticuloByIdQuery : IRequest<ArticuloDto>
    {
        public Guid Id { get; set; }

        public GetArticuloByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
