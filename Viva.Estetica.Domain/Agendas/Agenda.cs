using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Clientes;
using Viva.Estetica.Domain.Servicos;
using Viva.Estetica.Domain.Tecnicos;

namespace Viva.Estetica.Domain.Agendas
{
    public class Agenda : Entity
    {
        [Required]
        public Cliente Cliente { get; set; }
        
        [Required]
        public Servico Servico { get; set; }

        [Required]
        public DateTime DataAgendamento { get; set; }

        public bool HoraAgendamento()
        {
            TimeSpan start = new TimeSpan(8, 0, 0);
            TimeSpan end = new TimeSpan(16, 0, 0);

            TimeSpan now = DataAgendamento.TimeOfDay;
            if (start < end)
                return start <= now && now <= end;
            return !(end < now && now < start);
        }

        public bool AlteracaoAgendamento(int? minutos)
        {
            if (minutos != null)
            {
                DateTime data = new DateTime(DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day - 1, 23, 59, 59);
                if (data > DateTime.Now)
                {
                    if (DateTime.Now.AddMinutes(Convert.ToInt32(-minutos)) < DataAgendamento)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
