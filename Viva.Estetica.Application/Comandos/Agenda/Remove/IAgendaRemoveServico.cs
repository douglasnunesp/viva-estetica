using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Comandos.Agenda.Remove
{
    public interface IAgendaRemoveServico
    {
        bool Processa(AgendaRemoveCommand command, ref string mensagem);
    }
}
