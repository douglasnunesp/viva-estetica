using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Agendas;
using Viva.Estetica.Domain.Clientes;
using Viva.Estetica.Domain.Documentos;
using Viva.Estetica.Domain.Enderecos;
using Viva.Estetica.Domain.Servicos;
using Viva.Estetica.Domain.Tecnicos;

namespace Viva.Estetica.Infrastructure.SQLDataAccess
{
    public class Context : DbContext
    {
        public DbSet<Agenda> Agendas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Documento> Documentos { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Servico> Servicos { get; set; }

        public DbSet<Tecnico> Tecnicos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>().HasRequired<Cliente>(a => a.Cliente).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Agenda>().HasRequired<Servico>(a => a.Servico).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>().HasRequired<Documento>(c => c.Documento).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Cliente>().HasRequired<Endereco>(c => c.Endereco).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<Agenda>().ToTable("Agendas");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Documento>().ToTable("Documentos");
            modelBuilder.Entity<Endereco>().ToTable("Enderecos");
            modelBuilder.Entity<Servico>().ToTable("Servicos");
            modelBuilder.Entity<Tecnico>().ToTable("Tecnicos");

            base.OnModelCreating(modelBuilder);

        }

        //IDbSet<TEntity> IDbContext.Set<TEntity>()
        //{
        //    return base.Set<TEntity>();
        //}
    }
}

