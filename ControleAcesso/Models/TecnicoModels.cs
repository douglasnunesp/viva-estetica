using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Viva.Estetica.Site.Models
{
    public class TecnicoModels
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public DocumentoModels Documento { get; set; }

        public List<ServicoModels> Servicos { get; set; }

        public string Foto { get; set; }
    }
}