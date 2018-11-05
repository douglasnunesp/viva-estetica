using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Viva.Estetica.Site.Models
{
    public class ServicoModels
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public List<TecnicoModels> Tecnicos { get; set; }
    }
}