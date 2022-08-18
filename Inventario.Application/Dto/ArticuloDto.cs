﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Application.Dto
{
    public class ArticuloDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal CostoPromedio { get; set; }
        public decimal Stock { get; set; }

    }
}
