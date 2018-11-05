using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Retornos;
using Viva.Estetica.Domain.Clientes;

namespace Viva.Estetica.Application.Repositorios.Clientes
{
    public interface IClienteLeituraRepositorio
    {
        List<Cliente> Seleciona();
        Cliente Seleciona(Guid id);
        Cliente Seleciona(string login);
    }
}
