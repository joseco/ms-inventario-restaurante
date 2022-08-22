using Inventario.Domain.Events;
using Inventario.Domain.Models.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Factories
{
    public class ArticuloFactory : IArticuloFactory
    {
        public Articulo Create(string nombre, decimal precioVenta)
        {
            var obj = new Articulo(nombre);
            var domainEvent = new ArticuloCreado(obj.Id, nombre, precioVenta, DateTime.Now);

            obj.AddDomainEvent(domainEvent);

            return obj;
        }
    }
}
