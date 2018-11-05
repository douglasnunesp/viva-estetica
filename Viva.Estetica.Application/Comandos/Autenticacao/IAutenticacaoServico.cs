using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Retornos;

namespace Viva.Estetica.Application.Comandos.Autenticacao
{
    public interface IAutenticacaoServico
    {
        ClienteResult Autentica(AutenticacaoCommand command, ref string errorMessage);
    }
}
