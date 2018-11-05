using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Repositorios.Agendas;
using Viva.Estetica.Domain.Agendas;

namespace Viva.Estetica.Infrastructure.SQLDataAccess.Respositorios
{
    public class AgendaRepositorio : IAgendaLeituraRepositorio, IAgendaEscritaRepositorio
    {
        public void Adiciona(Agenda agenda)
        {
            using(Context context = new Context())
            {
                context.Entry(agenda.Cliente).State = EntityState.Unchanged;
                context.Entry(agenda.Servico).State = EntityState.Unchanged;
                context.Agendas.Add(agenda);
                context.SaveChanges();
            }
        }

        public void Atualiza(Agenda agenda)
        {
            using (Context context = new Context())
            {
                var resultado = context.Agendas.SingleOrDefault(x => x.Id == agenda.Id);
                resultado.Servico = agenda.Servico;
                resultado.DataAgendamento = agenda.DataAgendamento;
                context.Entry(agenda.Cliente).State = EntityState.Unchanged;
                context.Entry(agenda.Servico).State = EntityState.Unchanged;
                context.SaveChanges();
            }
        }

        public void Deleta(Guid id)
        {
            using (Context context = new Context())
            {
                var agenda = context.Agendas.SingleOrDefault(x => x.Id == id);
                context.Agendas.Remove(agenda);
                context.SaveChanges();
            }
        }

        public List<Agenda> Seleciona()
        {
            using (Context context = new Context())
            {
                return context.Agendas.ToList();
            }
        }

        public Agenda Seleciona(Guid id)
        {
            using (Context context = new Context())
            {
                return context.Agendas.Include("Servico").SingleOrDefault(x=> x.Id == id);
            }
        }

        public Agenda Seleciona(Guid servicoId,  DateTime data)
        {
            using (Context context = new Context())
            {
                return context.Agendas.Include("Servico").SingleOrDefault(x => x.Servico.Id == servicoId && x.DataAgendamento == data);
            }
        }
    }
}
