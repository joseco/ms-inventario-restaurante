using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.ValueObjects
{
    public record CostoInventario
    {
        public decimal Value { get; init; }

        public CostoInventario(decimal value)
        {
            if (value < 0)
            {
                throw new BussinessRuleValidationException("La cantidad no puede ser menor a 0");
            }
            Value = value;
        }

        public static implicit operator decimal(CostoInventario value)
        {
            return value.Value;
        }

        public static implicit operator CostoInventario(decimal value)
        {
            return new CostoInventario(value);
        }
    }
}
