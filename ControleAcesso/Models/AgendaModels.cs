using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Viva.Estetica.Site.Models
{
    public class AgendaModels
    {
        public Guid Id { get; set; }

        public ClienteModels Cliente { get; set; }

        public ServicoModels Servico { get; set; }


        public DateTime DataAgendamento { get; set; }
    }
}