using Inventario.Domain.Models.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Factories
{
    public interface IArticuloFactory
    {
        Articulo Create(string nombre, decimal precioVenta);
    }
}
