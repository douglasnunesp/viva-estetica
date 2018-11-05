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
    public class ClienteQuery : IClienteQuery
    {
        private readonly IResultConverter resultConverter;

        public ClienteQuery(IResultConverter resultConverter)
        {
            this.resultConverter = resultConverter;
        }
        public List<ClienteResult> Seleciona()
        {
            using (Context context = new Context())
            {
                return resultConverter.Map<List<ClienteResult>>(context.Clientes.ToList());
            }
        }

        public ClienteResult Seleciona(Guid id)
        {
            using (Context context = new Context())
            {
                var cliente = context.Clientes.Include("Documento").Include("Endereco").SingleOrDefault(x => x.Id == id);
                var clienteresult = resultConverter.Map<ClienteResult>(cliente);
                return clienteresult;
            }
        }
    }
}
