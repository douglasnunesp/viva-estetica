using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Comandos.Documentos;
using Viva.Estetica.Application.Comandos.Servicos;

namespace Viva.Estetica.Application.Comandos.Tecnicos.Adicionar
{
    public class AdicionarTecnicoComando
    {
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public DocumentoComando Documento { get; set; }

        public List<ServicoComando> Servicos { get; set; }

        public string Foto { get; set; }
    }
}
