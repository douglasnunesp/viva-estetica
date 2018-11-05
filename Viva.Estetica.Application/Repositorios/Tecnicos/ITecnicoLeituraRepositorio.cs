using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Tecnicos;

namespace Viva.Estetica.Application.Repositorios.Tecnicos
{
    public interface ITecnicoLeituraRepositorio
    {
        List<Tecnico> Tecnicos();
        Tecnico TecnicoId(Guid id);
        List<Tecnico> TecnicoServico(Guid id);
    }
}
