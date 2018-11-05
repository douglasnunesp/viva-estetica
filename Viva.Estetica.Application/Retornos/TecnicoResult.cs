using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Retornos
{
    public class TecnicoResult
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public DocumentoResult Documento { get; set; }

        public string Servicos { get; set; }

        public string Foto { get; set; }
    }
}
