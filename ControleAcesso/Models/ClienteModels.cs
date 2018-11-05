using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Viva.Estetica.Site.Models
{
    public class ClienteModels
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public DocumentoModels Documento { get; set; }

        public EnderecoModels Endereco { get; set; }

        public string NumeroCelular { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}