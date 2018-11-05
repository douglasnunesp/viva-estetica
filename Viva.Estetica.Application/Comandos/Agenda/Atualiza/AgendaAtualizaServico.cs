using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Repositorios.Agendas;
using Viva.Estetica.Application.Repositorios.Clientes;
using Viva.Estetica.Application.Repositorios.Servicos;
using Viva.Estetica.Application.Repositorios.Tecnicos;

namespace Viva.Estetica.Application.Comandos.Agenda.Atualiza
{
    public class AgendaAtualizaServico : IAgendaAtualizaServico
    {
        private readonly IAgendaEscritaRepositorio agendaEscritaRepositorio;
        private readonly IAgendaLeituraRepositorio agendaLeituraRepositorio;
        private readonly IClienteLeituraRepositorio clienteLeituraRepositorio;
        private readonly IServicoLeituraRepositorio servicoLeituraRepositorio;
        private readonly ITecnicoLeituraRepositorio tecnicoLeituraRepositorio;

        public AgendaAtualizaServico(IAgendaEscritaRepositorio agendaEscritaRepositorio,
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

        public bool Processa(AgendaAtualizaCommand command, ref string mensagemErro)
        {
            var agenda = agendaLeituraRepositorio.Seleciona(command.Id);
            if (agenda.HoraAgendamento())
            {
                if (agenda.AlteracaoAgendamento(agenda.Servico.TempoCancelamento))
                {
                    try
                    {
                        agenda.Cliente = clienteLeituraRepositorio.Seleciona(command.ClienteId);
                        agenda.DataAgendamento = command.DataAgendamento;
                        agenda.Servico = servicoLeituraRepositorio.Seleciona(command.ServicoId);
                        this.agendaEscritaRepositorio.Atualiza(agenda);
                        return true;
                    }
                    catch (Exception)
                    {
                        mensagemErro = "Desculpe tivemos uma erro no processamento de sua solicitação, tente novamente caso não consiga entrega em contato por telefone.";
                    }
                }
                
            }
            mensagemErro = "Expirado tempo de cancelamento ou reagendamento.";
            return false;
        }
    }
}
