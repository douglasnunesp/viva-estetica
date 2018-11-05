using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Repositorios.Clientes;

namespace Viva.Estetica.Application.Comandos.Cliente.Adiciona
{
    public class ClienteAdicionaServico : IClienteAdicionaServico
    {
        private readonly IClienteEscritaRepositorio clienteEscritaRepositorio;
        private readonly IClienteLeituraRepositorio clienteLeituraRepositorio;

        public ClienteAdicionaServico(IClienteEscritaRepositorio clienteEscritaRepositorio, IClienteLeituraRepositorio clienteLeituraRepositorio)
        {
            this.clienteEscritaRepositorio = clienteEscritaRepositorio;
            this.clienteLeituraRepositorio = clienteLeituraRepositorio;
        }

        public bool Processa(ClienteAdicionaCommand command, ref string mensagemErro)
        {
            Domain.Clientes.Cliente cliente = clienteLeituraRepositorio.Seleciona(command.Login);
            if (cliente == null)
            {
                cliente = new Domain.Clientes.Cliente()
                {
                    Login = command.Login,
                    Documento = new Domain.Documentos.Documento()
                    {
                        Passaport = command.Documento.Passaport,
                        RG = command.Documento.RG,
                    },
                    Endereco = new Domain.Enderecos.Endereco()
                    {
                        Bairro = command.Endereco.Bairro,
                        Cep = command.Endereco.Cep,
                        Cidade = command.Endereco.Cidade,
                        Logradouro = command.Endereco.Logradouro,
                        Numero = command.Endereco.Numero
                    },
                    Nome = command.Nome,
                    NumeroCelular = command.NumeroCelular,
                    Password = command.Password,
                    SobreNome = command.SobreNome
                };

                try
                {
                    clienteEscritaRepositorio.Adiciona(cliente);
                    return true;
                }
                catch (Exception ex)
                {
                    mensagemErro = ex.Message;
                    return false;
                }
            }
            else
            {
                mensagemErro = "Login já utilizado";
                return false;
            }
        }
    }
}
