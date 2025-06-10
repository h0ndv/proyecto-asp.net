using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class MVCContext : DbContext
    {
        public MVCContext (DbContextOptions<MVCContext> options)
            : base(options)
        {
        }

        public DbSet<MVC.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<MVC.Models.Usuarios> Usuarios { get; set; } = default!;
        public DbSet<MVC.Models.Productos> Productos { get; set; } = default!;
        public DbSet<MVC.Models.Perifericos> Perifericos { get; set; } = default!;
        public DbSet<MVC.Models.DetalleVenta> DetalleVenta { get; set; } = default!;
        public DbSet<MVC.Models.Ventas> Ventas { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasKey(u => u.IdUsuario);
            modelBuilder.Entity<Productos>().HasKey(p => p.IdProducto);
            modelBuilder.Entity<Perifericos>().HasKey(q => q.IdPeriferico);
            modelBuilder.Entity<Ventas>().HasKey(v => v.IdVenta);
            modelBuilder.Entity<DetalleVenta>().HasKey(dv => dv.IdDetalleVenta);
            modelBuilder.Entity<Ventas>()
                .HasMany(v => v.Detalles)
                .WithOne(dv => dv.Venta)
                .HasForeignKey(dv => dv.IdVenta);
        }
    }
}
