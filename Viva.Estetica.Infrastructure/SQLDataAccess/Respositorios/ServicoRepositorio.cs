using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Repositorios.Servicos;
using Viva.Estetica.Domain.Servicos;

namespace Viva.Estetica.Infrastructure.SQLDataAccess.Respositorios
{
    public class ServicoRepositorio : IServicoEscritaRepositorio, IServicoLeituraRepositorio
    {
        public void Adiciona(Servico servico)
        {
            using (Context context = new Context())
            {
                context.Servicos.Add(servico);
                context.SaveChanges();
            }
        }

        public void Atualiza(Servico servico)
        {
            using (Context context = new Context())
            {
                var resultado = context.Servicos.SingleOrDefault(x=> x.Id == servico.Id);
                if (resultado != null)
                {
                    resultado = servico;
                }
                context.SaveChanges();
            }
        }

        public void Deleta(Guid id)
        {
            using (Context context = new Context())
            {
                var resultado = context.Servicos.SingleOrDefault(x => x.Id == id);
                if (resultado != null)
                {
                    context.Servicos.Remove(resultado);
                }
                context.SaveChanges();
            }
        }

        public List<Servico> Seleciona()
        {
            using (Context context = new Context())
            {
                return context.Servicos.ToList();
            }
        }

        public Servico Seleciona(Guid id)
        {
            using (Context context = new Context())
            {
                return context.Servicos.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
