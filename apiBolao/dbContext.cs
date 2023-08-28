using apiBolao.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiBolao
{
    public class dbContext: DbContext
    {

        public dbContext() { }

        public dbContext(DbContextOptions options)
        : base(options) 
        {

        }

        public virtual DbSet<Times> Times { get; set; }
        public virtual DbSet<Tipos> Tipos { get; set; }
        public virtual DbSet<Partidas> Partidas { get; set; }
        public virtual DbSet<Boloes> Boloes { get; set; }
        public virtual DbSet<Apostas> Apostas { get; set; }
        public virtual DbSet<ApostasPartidas> ApostasPartidas { get; set; }
        public virtual DbSet<Campeonatos> Campeonatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=Designer\\RAFAELSQLSERVER;Initial Catalog=FUTROC;Integrated Security=True;");
            }
        }
    }
}
