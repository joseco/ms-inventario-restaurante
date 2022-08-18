using Inventario.Domain.Models.Transacciones;
using Inventario.Domain.Models.Transacciones.ValueObjects;
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
    public class TransaccionWriteConfig : IEntityTypeConfiguration<Transaccion>,
        IEntityTypeConfiguration<DetalleTransaccion>
    {
        public void Configure(EntityTypeBuilder<Transaccion> builder)
        {
            builder.ToTable("Transaccion");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FechaRegistro)
                .HasColumnName("fechaRegistro")
                .IsRequired();

            builder.Property(x => x.FechaConfirmacion)
                .HasColumnName("fechaConfirmacion");

            builder.Property(x => x.FechaAnulacion)
                 .HasColumnName("fechaAnulacion");

            var tipoConverter = new ValueConverter<TipoTransaccion, string>(
                tipoEnumValue => tipoEnumValue.ToString(),
                tipo => (TipoTransaccion)Enum.Parse(typeof(TipoTransaccion), tipo)
            );

            builder.Property(x => x.Tipo)
                 .HasConversion(tipoConverter)
                 .HasColumnName("tipo")
                 .HasMaxLength(20)
                 .IsRequired();

            
            var estadoConverter = new ValueConverter<EstadoTransaccion, string>(
                estadoEnumValue => estadoEnumValue.ToString(),
                estado => (EstadoTransaccion)Enum.Parse(typeof(EstadoTransaccion), estado)
            );

            builder.Property(x => x.Estado)
                 .HasConversion(estadoConverter)
                 .HasColumnName("estado")
                 .HasMaxLength(20)
                 .IsRequired();

            builder.HasMany(typeof(DetalleTransaccion), "_detalle");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.DetalleTransaccion);
        }

        public void Configure(EntityTypeBuilder<DetalleTransaccion> builder)
        {
            builder.ToTable("DetalleTransaccion");
            builder.HasKey(x => x.Id);

            var cantidadConverter = new ValueConverter<CantidadTransaccion, decimal>(
                cantidadValue => cantidadValue.Value,
                cantidad => new CantidadTransaccion(cantidad)
            );

            builder.Property(x => x.Cantidad)
                .HasConversion(cantidadConverter)
                .HasColumnName("cantidad")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            var costoInventarioConverter = new ValueConverter<CostoInventario, decimal>(
                costoValue => costoValue.Value,
                costo => new CostoInventario(costo)
            );

            builder.Property(x => x.CostoUnitario)
                .HasConversion(costoInventarioConverter)
                .HasColumnName("costoUnitario")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.CostoTotal)
                .HasConversion(costoInventarioConverter)
                .HasColumnName("costoTotal")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
