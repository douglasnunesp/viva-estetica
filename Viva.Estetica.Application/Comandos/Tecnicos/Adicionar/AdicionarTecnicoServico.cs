using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Repositorios.Tecnicos;

namespace Viva.Estetica.Application.Comandos.Tecnicos.Adicionar
{
    public class AdicionarTecnicoServico : IAdicionarTecnicoServico
    {
        private readonly ITecnicoEscritaRepositorio tecnicoEscritaRepositorio;

        public AdicionarTecnicoServico(ITecnicoEscritaRepositorio tecnicoEscritaRepositorio)
        {
            this.tecnicoEscritaRepositorio = tecnicoEscritaRepositorio;
        }

        public void Processa(AdicionarTecnicoComando comando)
        {
            this.tecnicoEscritaRepositorio.Adiciona(new Domain.Tecnicos.Tecnico()
            {
                Documento = new Domain.Documentos.Documento()
                {
                    Passaport = comando.Documento.Passaport,
                    RG = comando.Documento.RG
                },
                Foto = comando.Foto,
                Nome = comando.Nome,
                SobreNome = comando.SobreNome,
            });
        }
    }
}
