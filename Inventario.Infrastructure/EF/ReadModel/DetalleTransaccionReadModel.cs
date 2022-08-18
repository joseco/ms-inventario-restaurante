using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.EF.ReadModel
{
    public class DetalleTransaccionReadModel
    {
        public Guid Id { get; set; }

        public ArticuloReadModel Articulo { get; set; }
        public Guid ArticuloId { get; set; }

        public TransaccionReadModel Transaccion { get; set; }
        public Guid TransaccionId { get; set; }

        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }

        public decimal CostoTotal { get; set; }
    }
}
