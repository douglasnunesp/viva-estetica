using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Retornos;
using Viva.Estetica.Domain.Tecnicos;

namespace Viva.Estetica.Infrastructure.Mapeamentos
{
    public class TecnicoProfile : Profile
    {
        public TecnicoProfile()
        {
            CreateMap<Tecnico, TecnicoResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Servicos, opt => opt.MapFrom(src => src.Servicos.Select(x => x.Nome)))
                .ForMember(dest => dest.SobreNome, opt => opt.MapFrom(src => src.SobreNome))
                .ForMember(dest => dest.Documento, opt => opt.MapFrom(src => src.Documento))
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => src.Foto));
        }
    }
}
