using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Retornos;
using Viva.Estetica.Domain.Documentos;

namespace Viva.Estetica.Infrastructure.Mapeamentos
{
    public class DocumentoProfile : Profile
    {
        public DocumentoProfile()
        {
            CreateMap<Documento, DocumentoResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Passaport, opt => opt.MapFrom(src => src.Passaport))
                .ForMember(dest => dest.RG, opt => opt.MapFrom(src => src.RG));
        }
    }
}
