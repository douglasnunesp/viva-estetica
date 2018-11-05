using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Repositorios.Clientes;
using Viva.Estetica.Application.Retornos;

namespace Viva.Estetica.Application.Comandos.Autenticacao
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        private readonly IClienteLeituraRepositorio clienteLeituraRepositorio;
        private readonly IResultConverter resultConverter;

        public AutenticacaoServico(IClienteLeituraRepositorio clienteLeituraRepositorio, IResultConverter resultConverter)
        {
            this.clienteLeituraRepositorio = clienteLeituraRepositorio;
            this.resultConverter = resultConverter;
        }

        public ClienteResult Autentica(AutenticacaoCommand command, ref string errorMessage)
        {
            var cliente= clienteLeituraRepositorio.Seleciona(command.Usuario);
            if(cliente != null)
            {
                if(cliente.Password == command.Senha)
                {
                    return this.resultConverter.Map<ClienteResult>(cliente);
                }

                errorMessage = "Senha inválida";
                return null;

            }
            errorMessage = "Usuário não encontrado";
            return null;
        }
    }
}
