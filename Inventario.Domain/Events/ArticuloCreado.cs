using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Events
{
    public record ArticuloCreado : DomainEvent
    {

        public Guid ArticuloId { get; set; }
        public string Nombre { get; set; }

        public decimal PrecioVenta { get; set; }

        public ArticuloCreado(Guid articuloId, string nombre, decimal precioVenta, DateTime occuredOn) : base(occuredOn)
        {
            ArticuloId = articuloId;
            Nombre = nombre;
            PrecioVenta = precioVenta;
        }
    }
}
