﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Agendas;

namespace Viva.Estetica.Application.Repositorios.Agendas
{
    public interface IAgendaLeituraRepositorio
    {
        List<Agenda> Seleciona();
        Agenda Seleciona(Guid id);
        Agenda Seleciona(Guid servicoId,  DateTime data);
    }
}
