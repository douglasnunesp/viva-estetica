using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Comandos.Cliente.Remove
{
    public interface IClienteRemoveServico
    {
        bool Processa(ClienteRemoveCommand command);
    }
}
