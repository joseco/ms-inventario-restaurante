﻿using Inventario.Domain.Events;
using Inventario.Infrastructure.EF.Config.ReadConfig;
using Inventario.Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Infrastructure.EF.Contexts
{
    public class ReadDbContext : DbContext
    {
        public virtual DbSet<ArticuloReadModel> Articulo { set; get; }
        public virtual DbSet<TransaccionReadModel> Transaccion { set; get; }
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var articuloConfig = new ArticuloReadConfig();
            modelBuilder.ApplyConfiguration(articuloConfig);

            var transaccionConfig = new TransaccionReadConfig();
            modelBuilder.ApplyConfiguration<TransaccionReadModel>(transaccionConfig);
            modelBuilder.ApplyConfiguration<DetalleTransaccionReadModel>(transaccionConfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<TransaccionConfirmada>();
        }
    }
}
