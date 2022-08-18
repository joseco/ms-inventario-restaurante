using Inventario.Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.EF.Config.ReadConfig
{
    public class TransaccionReadConfig : IEntityTypeConfiguration<TransaccionReadModel>,
        IEntityTypeConfiguration<DetalleTransaccionReadModel>
    {
        public void Configure(EntityTypeBuilder<TransaccionReadModel> builder)
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
            
            builder.Property(x => x.Tipo)
                 .HasColumnName("tipo")
                 .HasMaxLength(20)
                 .IsRequired();

            builder.Property(x => x.Estado)
                 .HasColumnName("estado")
                 .HasMaxLength(20)
                 .IsRequired();

            builder.HasMany(x => x.Detalle)
                .WithOne(x => x.Transaccion);
        }
        public void Configure(EntityTypeBuilder<DetalleTransaccionReadModel> builder)
        {
            builder.ToTable("DetalleTransaccion");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cantidad)
                .HasColumnName("cantidad")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.CostoUnitario)
                .HasColumnName("costoUnitario")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.CostoTotal)
                .HasColumnName("costoTotal")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

        }

    }
}
