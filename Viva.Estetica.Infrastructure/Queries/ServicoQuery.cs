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
    public class ServicoQuery : IServicoQuery
    {
        private readonly IResultConverter resultConverter;

        public ServicoQuery(IResultConverter resultConverter)
        {
            this.resultConverter = resultConverter;
        }

        public List<ServicoResult> Seleciona()
        {
            using (Context context = new Context())
            {
                return resultConverter.Map<List<ServicoResult>>(context.Servicos.ToList());
            }
        }

        public ServicoResult Seleciona(Guid id)
        {
            using (Context context = new Context())
            {
                var servico = context.Servicos.SingleOrDefault(x => x.Id == id);
                var servicoresult = resultConverter.Map<ServicoResult>(servico);
                return servicoresult;
            }
        }
    }
}
