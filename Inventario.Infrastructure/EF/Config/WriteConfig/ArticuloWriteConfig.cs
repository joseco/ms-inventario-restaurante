using Inventario.Domain.Models.Articulos;
using Inventario.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.EF.Config.WriteConfig
{
    public class ArticuloWriteConfig : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.ToTable("Articulo");
            builder.HasKey(x => x.Id);

            var nombreConverter = new ValueConverter<NombreArticulo, string>(
                nombreValue => nombreValue.Value,
                nombre => new NombreArticulo(nombre)
            );

            builder.Property(x => x.Nombre)
                .HasConversion(nombreConverter)
                .HasColumnName("nombre")
                .HasMaxLength(500);

            var costoConverter = new ValueConverter<CostoInventario, decimal>(
                costoValue => costoValue.Value,
                costo => new CostoInventario(costo)
            );

            builder.Property(x => x.CostoPromedio)
                .HasConversion(costoConverter)
                .HasColumnName("costoPromedio")
                .HasPrecision(12, 2);

            builder.Property(x => x.Stock)
                .HasColumnName("stock")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);
        }
    }
}
