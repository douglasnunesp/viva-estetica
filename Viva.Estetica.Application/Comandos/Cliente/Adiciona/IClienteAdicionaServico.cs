using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Comandos.Cliente.Adiciona
{
    public interface IClienteAdicionaServico
    {
        bool Processa(ClienteAdicionaCommand command, ref string mensagemErro);
    }
}
