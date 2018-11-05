using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Retornos
{
    public class ServicoResult
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public TimeSpan Duracao { get; set; }

        public int TempoCancelamento { get; set; }
    }
}
