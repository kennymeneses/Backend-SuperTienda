using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;
using SuperTienda.Common.Entities;
using SuperTienda.Common.Configuration;

namespace SuperTienda.DataAccess.Core
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuracion = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(configuracion.GetSection("ConnectionStrings")["DefaultConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual void Save()
        {
            base.SaveChanges();
        }


        #region Entidades representando objetos de la base de datos

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<SubSubCategoria> SubSubCategorias { get; set; }
        public DbSet<Producto> Productos { get; set; }


        #endregion
    }
}
