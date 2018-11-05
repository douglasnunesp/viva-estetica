using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Tecnicos;

namespace Viva.Estetica.Application.Repositorios.Tecnicos
{
    public interface ITecnicoEscritaRepositorio
    {
        void Adiciona(Tecnico tecnico);

        void Atualiza(Tecnico tecnico);

        void Deleta(Guid id);
    }
}
