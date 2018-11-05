using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Repositorios.Clientes;
using Viva.Estetica.Application.Retornos;
using Viva.Estetica.Domain.Clientes;

namespace Viva.Estetica.Infrastructure.SQLDataAccess.Respositorios
{
    public class ClienteRepositorio : IClienteEscritaRepositorio, IClienteLeituraRepositorio
    {
        public void Adiciona(Cliente cliente)
        {
            using(Context context= new Context())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }

        public void Altera(Cliente cliente)
        {
            using (Context context = new Context())
            {
                var resultado = context.Clientes.SingleOrDefault(x => x.Id == cliente.Id);
                resultado.Documento = cliente.Documento;
                resultado.Endereco = cliente.Endereco;
                resultado.Nome = cliente.Nome;
                resultado.NumeroCelular = cliente.NumeroCelular;
                resultado.Password = cliente.Password;
                resultado.SobreNome = cliente.SobreNome;
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (Context context = new Context())
            {
                var resultado = context.Clientes.SingleOrDefault(x => x.Id == id);
                context.Clientes.Remove(resultado);
                context.SaveChanges();
            }
        }

        public List<Cliente> Seleciona()
        {
            using (Context context = new Context())
            {
                return context.Clientes.ToList();
            }
        }

        public Cliente Seleciona(Guid id)
        {
            using (Context context = new Context())
            {
                return context.Clientes.Include("Documento").Include("Endereco").SingleOrDefault(x => x.Id == id);
            }
        }

        public Cliente Seleciona(string login)
        {
            using (Context context = new Context())
            {
                return context.Clientes.Include("Documento").Include("Endereco").SingleOrDefault(x => x.Login == login);
            }
        }
    }
}
