using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Application.UseCases.Command.Articulos.CrearArticulo
{
    public class CrearArticuloCommand : IRequest<Guid>
    {
        public string NombreArticulo { get; private set; }

        public decimal PrecioVenta { get; private set; }

        public CrearArticuloCommand(string nombreArticulo, decimal precioVenta)
        {
            NombreArticulo = nombreArticulo;
            PrecioVenta = precioVenta;
        }

        private CrearArticuloCommand()
        {

        }

    }
}
