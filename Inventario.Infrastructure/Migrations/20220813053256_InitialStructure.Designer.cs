﻿// <auto-generated />
using System;
using Inventario.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventario.Infrastructure.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    [Migration("20220813053256_InitialStructure")]
    partial class InitialStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Inventario.Infrastructure.EF.ReadModel.ArticuloReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CostoPromedio")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("costoPromedio");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("nombre");

                    b.Property<decimal>("Stock")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("stock");

                    b.HasKey("Id");

                    b.ToTable("Articulo", (string)null);
                });

            modelBuilder.Entity("Inventario.Infrastructure.EF.ReadModel.DetalleTransaccionReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArticuloId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cantidad")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("cantidad");

                    b.Property<decimal>("CostoTotal")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("costoTotal");

                    b.Property<decimal>("CostoUnitario")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("costoUnitario");

                    b.Property<Guid>("TransaccionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("TransaccionId");

                    b.ToTable("DetalleTransaccion", (string)null);
                });

            modelBuilder.Entity("Inventario.Infrastructure.EF.ReadModel.TransaccionReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("estado");

                    b.Property<DateTime?>("FechaAnulacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaAnulacion");

                    b.Property<DateTime?>("FechaConfirmacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaConfirmacion");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaRegistro");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.ToTable("Transaccion", (string)null);
                });

            modelBuilder.Entity("Inventario.Infrastructure.EF.ReadModel.DetalleTransaccionReadModel", b =>
                {
                    b.HasOne("Inventario.Infrastructure.EF.ReadModel.ArticuloReadModel", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventario.Infrastructure.EF.ReadModel.TransaccionReadModel", "Transaccion")
                        .WithMany("Detalle")
                        .HasForeignKey("TransaccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Transaccion");
                });

            modelBuilder.Entity("Inventario.Infrastructure.EF.ReadModel.TransaccionReadModel", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
