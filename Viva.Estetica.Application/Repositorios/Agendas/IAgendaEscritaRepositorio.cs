using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Agendas;

namespace Viva.Estetica.Application.Repositorios.Agendas
{
    public interface IAgendaEscritaRepositorio
    {
        void Adiciona(Agenda agenda);
        void Atualiza(Agenda agenda);
        void Deleta(Guid id);
    }
}
