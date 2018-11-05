using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Repositorios.Agendas;
using Viva.Estetica.Application.Repositorios.Clientes;
using Viva.Estetica.Application.Repositorios.Servicos;
using Viva.Estetica.Application.Repositorios.Tecnicos;

namespace Viva.Estetica.Application.Comandos.Agenda.Marca
{
    public class AgendaMarcaServico : IAgendaMarcaServico
    {
        private readonly IAgendaEscritaRepositorio agendaEscritaRepositorio;
        private readonly IAgendaLeituraRepositorio agendaLeituraRepositorio;
        private readonly IClienteLeituraRepositorio clienteLeituraRepositorio;
        private readonly IServicoLeituraRepositorio servicoLeituraRepositorio;
        private readonly ITecnicoLeituraRepositorio tecnicoLeituraRepositorio;

        public AgendaMarcaServico(IAgendaEscritaRepositorio agendaEscritaRepositorio, 
            IAgendaLeituraRepositorio agendaLeituraRepositorio, 
            IClienteLeituraRepositorio clienteLeituraRepositorio,
            IServicoLeituraRepositorio servicoLeituraRepositorio,
            ITecnicoLeituraRepositorio tecnicoLeituraRepositorio)
        {
            this.agendaEscritaRepositorio = agendaEscritaRepositorio;
            this.agendaLeituraRepositorio = agendaLeituraRepositorio;
            this.clienteLeituraRepositorio = clienteLeituraRepositorio;
            this.servicoLeituraRepositorio = servicoLeituraRepositorio;
            this.tecnicoLeituraRepositorio = tecnicoLeituraRepositorio;
        }

        public bool Processa(AgendaMarcaCommand command)
        {
            Domain.Agendas.Agenda agenda = new Domain.Agendas.Agenda()
            {
                Cliente = clienteLeituraRepositorio.Seleciona(command.ClienteId),
                DataAgendamento = command.DataAgendamento,
                Servico = servicoLeituraRepositorio.Seleciona(command.ServicoId),
            };

            if (agenda.HoraAgendamento())
            {
                try
                {
                    this.agendaEscritaRepositorio.Adiciona(agenda);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Desculpe tivemos uma erro no processamento de sua solicitação, tente novamente caso não consiga entrega em contato por telefone.");
                }
            }
            return false;
        }

       
    }
}
