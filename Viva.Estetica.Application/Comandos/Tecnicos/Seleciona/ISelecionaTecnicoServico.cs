using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Comandos.Tecnicos.Seleciona
{
    public interface ISelecionaTecnicoServico
    {
        List<SelecionaTecnicosResult> Lista();
        SelecionaTecnicosResult Seleciona(Guid id);
    }
}
