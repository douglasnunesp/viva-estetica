﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Clientes;

namespace Viva.Estetica.Domain.Documentos
{
    public class Documento : Entity
    {
        [Required]
        public string RG { get; set; }
        [Required]
        public string Passaport { get; set; }
    }
}
