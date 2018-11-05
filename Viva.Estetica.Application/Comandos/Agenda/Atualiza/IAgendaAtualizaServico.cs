using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Comandos.Agenda.Atualiza
{
    public interface IAgendaAtualizaServico
    {
        bool Processa(AgendaAtualizaCommand command, ref string mensagemErro);
    }
}
