using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Viva.Estetica.Site.Models
{
    public class Authentication
    {
        public Guid Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DocumentoModels Documento { get; set; }
        public EnderecoModels Endereco { get; set; }
    }
}