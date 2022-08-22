using Inventario.Domain.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Models.Articulos
{
    public class Articulo : AggregateRoot<Guid>
    {
        public NombreArticulo Nombre { get; private set; }
        public CostoInventario CostoPromedio { get; private set; }
        public decimal Stock { get; private set; }

        private Articulo() { }

        internal Articulo(string nombre)
        {            
            Id = Guid.NewGuid();
            Nombre = nombre;
            CostoPromedio = new CostoInventario(0);
            Stock = 0m;
        }

        public void ActualizarStockYCostoPromedio(decimal costoUnitario, int cantidadAdicional)
        {
            CostoPromedio = (CostoPromedio * Stock + costoUnitario * cantidadAdicional) / (Stock + cantidadAdicional);
            Stock += cantidadAdicional;
        }
        public void ActualizarNombre(string nombre)
        {
            Nombre = nombre;
        }

    }
}
