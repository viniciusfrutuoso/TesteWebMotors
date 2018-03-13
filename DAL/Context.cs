using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class Context : DbContext
    {
        public Context() : base("conexao")
        {
            Database.SetInitializer<Context>(null);

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnuncioMap());
        }

       public DbSet<Anuncio> Anuncio { get; set; }

    }
}