using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Repositorios.Tecnicos;

namespace Viva.Estetica.Application.Comandos.Tecnicos.Seleciona
{
    public class SelecionaTecnicoServico : ISelecionaTecnicoServico
    {
        private readonly ITecnicoLeituraRepositorio tecnicoLeituraRepositorio;
        private readonly IResultConverter resultConverter;
        public SelecionaTecnicoServico(ITecnicoLeituraRepositorio tecnicoLeituraRepositorio, IResultConverter resultConverter)
        {
            this.tecnicoLeituraRepositorio = tecnicoLeituraRepositorio;
            this.resultConverter = resultConverter;
        }

        public List<SelecionaTecnicosResult> Lista()
        {
            var tecnicos = tecnicoLeituraRepositorio.Tecnicos();
            return resultConverter.Map<List<SelecionaTecnicosResult>>(tecnicos);
        }

        public SelecionaTecnicosResult Seleciona(Guid id)
        {
            var tecnico = tecnicoLeituraRepositorio.TecnicoId(id);
            return resultConverter.Map<SelecionaTecnicosResult>(tecnico);
        }
    }
}
