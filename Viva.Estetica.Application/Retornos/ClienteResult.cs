using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Retornos
{
    public class ClienteResult
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        
        public string SobreNome { get; set; }

        public DocumentoResult Documento { get; set; }

        public EnderecoResult Endereco { get; set; }

        public string NumeroCelular { get; set; }

        public string login { get; set; }

        public string password { get; set; }
    }
}
