using Inventario.Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.Infrastructure.EF.Config.ReadConfig
{
    public class ArticuloReadConfig : IEntityTypeConfiguration<ArticuloReadModel>
    {
        public void Configure(EntityTypeBuilder<ArticuloReadModel> builder)
        {
            builder.ToTable("Articulo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(500);

            builder.Property(x => x.CostoPromedio)
                .HasColumnName("costoPromedio")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.Stock)
                .HasColumnName("stock")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

        }
    }
}
