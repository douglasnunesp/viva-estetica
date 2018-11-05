using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Documentos;
using Viva.Estetica.Domain.Servicos;

namespace Viva.Estetica.Domain.Tecnicos
{
    public class Tecnico : Entity
    {
        [Required]
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        [Required]
        public Documento Documento { get; set; }

        public List<Servico> Servicos { get; set; }

        public string Foto { get; set; }
    }
}
