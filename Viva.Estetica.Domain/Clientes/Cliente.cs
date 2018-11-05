using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Documentos;
using Viva.Estetica.Domain.Enderecos;

namespace Viva.Estetica.Domain.Clientes
{
    public class Cliente : Entity
    {
        [Required, MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(50)]
        public string SobreNome { get; set; }

        [Required]
        public Documento Documento { get; set; }

        public Endereco Endereco { get; set; }

        [Required, MaxLength(20)]
        public string NumeroCelular { get; set; }

        [Required, MaxLength(50)]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
