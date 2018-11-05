using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Comandos.Cliente.Atualiza
{
    public interface IClienteAtualizaServico
    {
        bool Processa(ClienteAtualizaCommand command, ref string mensagemErro);
    }
}
