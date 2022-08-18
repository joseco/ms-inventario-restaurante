using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.ValueObjects
{
    public record NombreArticulo : ValueObject
    {
        public string Value { get; set; }
        public NombreArticulo(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            if (value.Length > 500)
            {
                throw new BussinessRuleValidationException("NombreArticulo can't be more than 500 characters");
            }
            Value = value;
        }

        public static implicit operator string(NombreArticulo value)
        {
            return value.Value;
        }

        public static implicit operator NombreArticulo(string name)
        {
            return new NombreArticulo(name);
        }
    }
}
