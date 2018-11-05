using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Comandos.Agenda.Marca
{
    public interface IAgendaMarcaServico
    {
        bool Processa(AgendaMarcaCommand command);
    }
}
