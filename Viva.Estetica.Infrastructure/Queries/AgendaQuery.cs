using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application;
using Viva.Estetica.Application.Queries;
using Viva.Estetica.Application.Retornos;
using Viva.Estetica.Infrastructure.SQLDataAccess;

namespace Viva.Estetica.Infrastructure.Queries
{
    public class AgendaQuery : IAgendaQuery
    {
        private readonly IResultConverter resultConverter;

        public AgendaQuery(IResultConverter resultConverter)
        {
            this.resultConverter = resultConverter;
        }

        public AgendaResult Seleciona(Guid id)
        {
            using (Context context = new Context())
            {
                return resultConverter.Map<AgendaResult>(context.Agendas.Include("Cliente").Include("Servico").SingleOrDefault(x => x.Id == id));
            }
        }

        public List<AgendaResult> SelecionaCliente(Guid clienteId)
        {
            using (Context context = new Context())
            {
                return resultConverter.Map<List<AgendaResult>>(context.Agendas.Include("Cliente").Include("Servico").Where(x=> x.Cliente.Id == clienteId).ToList());
            }
        }
    }
}
