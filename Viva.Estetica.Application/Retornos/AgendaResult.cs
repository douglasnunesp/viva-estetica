using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Retornos
{
    public class AgendaResult
    {
        public Guid Id { get; set; }

        public ClienteResult Cliente { get; set; }

        public ServicoResult Servico { get; set; }

        public DateTime DataAgendamento { get; set; }

    }
}
