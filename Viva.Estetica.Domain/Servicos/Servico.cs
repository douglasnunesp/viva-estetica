using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Tecnicos;

namespace Viva.Estetica.Domain.Servicos
{
    public class Servico : Entity
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public TimeSpan Duracao { get; set; }

        public int? TempoCancelamento { get; set; }
    }
}
