using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Comandos.Agenda.Atualiza
{
    public class AgendaAtualizaCommand
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid ServicoId { get; set; }
        public DateTime DataAgendamento { get; set; }
    }
}
