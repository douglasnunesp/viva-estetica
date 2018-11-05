using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Servicos;

namespace Viva.Estetica.Application.Repositorios.Servicos
{
    public interface IServicoEscritaRepositorio
    {
        void Adiciona(Servico servico);
        void Atualiza(Servico servico);
        void Deleta(Guid id);
    }
}
