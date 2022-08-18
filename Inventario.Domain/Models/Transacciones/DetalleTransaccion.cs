using Inventario.Domain.Models.Transacciones.ValueObjects;
using Inventario.Domain.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Models.Transacciones
{
    public class DetalleTransaccion : Entity<Guid>
    {
        public Guid ArticuloId { get; private set; }
        public CantidadTransaccion Cantidad { get; private set; }
        public CostoInventario CostoUnitario { get; private set; }
        public CostoInventario CostoTotal { get; private set; }

        public DetalleTransaccion(Guid articuloId, decimal cantidad, decimal costoUnitario)
        {
            Id = Guid.NewGuid();
            ArticuloId = articuloId;
            Cantidad = cantidad;
            CostoTotal = costoUnitario;
            CostoTotal = costoUnitario * cantidad;
        }

        private DetalleTransaccion() { }

    }
}
