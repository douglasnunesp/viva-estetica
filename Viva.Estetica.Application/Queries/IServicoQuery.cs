using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Retornos;

namespace Viva.Estetica.Application.Queries
{
    public interface IServicoQuery
    {
        List<ServicoResult> Seleciona();
        ServicoResult Seleciona(Guid id);
    }
}
