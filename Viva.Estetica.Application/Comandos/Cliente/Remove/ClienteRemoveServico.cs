using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Repositorios.Clientes;

namespace Viva.Estetica.Application.Comandos.Cliente.Remove
{
    public class ClienteRemoveServico : IClienteRemoveServico
    {
        private readonly IClienteEscritaRepositorio clienteEscritaRepositorio;
        private readonly IClienteLeituraRepositorio clienteLeituraRepositorio;

        public ClienteRemoveServico(IClienteEscritaRepositorio clienteEscritaRepositorio, IClienteLeituraRepositorio clienteLeituraRepositorio)
        {
            this.clienteEscritaRepositorio = clienteEscritaRepositorio;
            this.clienteLeituraRepositorio = clienteLeituraRepositorio;
        }

        public bool Processa(ClienteRemoveCommand command)
        {
            try
            {
                clienteEscritaRepositorio.Delete(command.Id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
