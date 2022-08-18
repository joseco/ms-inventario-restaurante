using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.EF.ReadModel
{
    public class ArticuloReadModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal CostoPromedio { get; set; }
        public decimal Stock { get; set; }
    }
}
