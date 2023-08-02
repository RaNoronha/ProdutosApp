using Microsoft.EntityFrameworkCore;
using ProdutosApp.Data.Entities;
using ProdutosApp.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Contexts
{
    public class DataContext : DbContext
    {
        #region Conexão com BD

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL5106.site4now.net;Initial Catalog=db_a9cd60_bdprodutosapp;User Id=db_a9cd60_bdprodutosapp_admin;Password=Lz5365@pq");
        }

        #endregion

        #region Classes de mapeamento

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

        #endregion

        #region Acesso CRUD

        public DbSet<Produto> Produto { get; set; }

        #endregion
    }
}
