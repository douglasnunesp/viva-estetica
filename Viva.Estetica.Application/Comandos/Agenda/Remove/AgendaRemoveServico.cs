using System;
using Viva.Estetica.Application.Repositorios.Agendas;

namespace Viva.Estetica.Application.Comandos.Agenda.Remove
{
    public class AgendaRemoveServico : IAgendaRemoveServico
    {
        private readonly IAgendaEscritaRepositorio agendaEscritaRepositorio;
        private readonly IAgendaLeituraRepositorio agendaLeituraRepositorio;


        public AgendaRemoveServico(IAgendaEscritaRepositorio agendaEscritaRepositorio, IAgendaLeituraRepositorio agendaLeituraRepositorio)
        {
            this.agendaEscritaRepositorio = agendaEscritaRepositorio;
            this.agendaLeituraRepositorio = agendaLeituraRepositorio;
           
        }
        public bool Processa(AgendaRemoveCommand command, ref string mensagemErro)
        {
            var agenda = agendaLeituraRepositorio.Seleciona(command.Id);
            if (agenda.HoraAgendamento())
            {
                if (agenda.AlteracaoAgendamento(agenda.Servico.TempoCancelamento))
                {
                    try
                    {
                        this.agendaEscritaRepositorio.Deleta(command.Id);
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Desculpe tivemos uma erro no processamento de sua solicitação, tente novamente caso não consiga entrega em contato por telefone.");
                    }
                }
            }
            mensagemErro = "Expirado tempo de cancelamento ou reagendamento.";
            return false;
        }
    }
}
