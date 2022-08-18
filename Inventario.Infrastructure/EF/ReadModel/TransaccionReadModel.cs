using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.EF.ReadModel
{
    public class TransaccionReadModel
    {
        public Guid Id { get; set; }
        public DateTime FechaRegistro { get; private set; }
        public DateTime? FechaConfirmacion { get; private set; }
        public DateTime? FechaAnulacion { get; private set; }

        public string Estado { get; set; }
        public string Tipo { get; set; }
        public List<DetalleTransaccionReadModel> Detalle { get; set; }
    }
}
