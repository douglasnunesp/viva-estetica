using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Comandos.Cliente.Atualiza
{
    public class ClienteAtualizaCommand
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string NumeroCelular { get; set; }

        public DocumentoCommand Documento { get; set; }

        public EnderecoCommand Endereco { get; set; }
    }


    public class DocumentoCommand
    {
        public string RG { get; set; }

        public string Passaport { get; set; }

    }

    public class EnderecoCommand
    {
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Cep { get; set; }
    }
}
