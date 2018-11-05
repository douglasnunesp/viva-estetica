using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Clientes;

namespace Viva.Estetica.Application.Repositorios.Clientes
{
    public interface IClienteEscritaRepositorio
    {
        void Adiciona(Cliente cliente);
        void Altera(Cliente cliente);
        void Delete(Guid id);
    }
}
