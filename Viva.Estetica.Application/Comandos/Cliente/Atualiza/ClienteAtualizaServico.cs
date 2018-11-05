using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Repositorios.Clientes;

namespace Viva.Estetica.Application.Comandos.Cliente.Atualiza
{
    public class ClienteAtualizaServico : IClienteAtualizaServico
    {

        private readonly IClienteEscritaRepositorio clienteEscritaRepositorio;
        private readonly IClienteLeituraRepositorio clienteLeituraRepositorio;

        public ClienteAtualizaServico(IClienteEscritaRepositorio clienteEscritaRepositorio, IClienteLeituraRepositorio clienteLeituraRepositorio)
        {
            this.clienteEscritaRepositorio = clienteEscritaRepositorio;
            this.clienteLeituraRepositorio = clienteLeituraRepositorio;
        }

        public bool Processa(ClienteAtualizaCommand command, ref string mensagemErro)
        {
            var cliente = clienteLeituraRepositorio.Seleciona(command.Id);
            if(cliente != null )
            {
                cliente.Login = command.Login;
                cliente.Documento = new Domain.Documentos.Documento()
                {
                    Passaport = command.Documento.Passaport,
                    RG = command.Documento.RG,
                };
                cliente.Endereco = new Domain.Enderecos.Endereco()
                {
                    Bairro = command.Endereco.Bairro,
                    Cep = command.Endereco.Cep,
                    Cidade = command.Endereco.Cidade,
                    Logradouro = command.Endereco.Logradouro,
                    Numero = command.Endereco.Numero
                };
                cliente.Nome = command.Nome;
                cliente.NumeroCelular = command.NumeroCelular;
                cliente.Password = command.Password;
                cliente.SobreNome = command.SobreNome;

                try
                {
                    clienteEscritaRepositorio.Altera(cliente);
                    return true;
                }
                catch (Exception ex)
                {
                    mensagemErro = ex.Message;
                    return false;
                }
            }
            mensagemErro = "Usuário não encontrado.";
            return false;
        }
    }
}
