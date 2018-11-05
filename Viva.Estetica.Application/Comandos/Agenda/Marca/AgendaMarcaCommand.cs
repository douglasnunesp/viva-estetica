using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Comandos.Agenda.Marca
{
    public class AgendaMarcaCommand
    {
        public Guid ClienteId { get; set; }
        public Guid ServicoId { get; set; }
        public DateTime DataAgendamento { get; set; }
    }
}
