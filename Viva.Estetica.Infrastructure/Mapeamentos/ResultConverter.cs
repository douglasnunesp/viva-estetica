using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application;

namespace Viva.Estetica.Infrastructure.Mapeamentos
{
    public class ResultConverter : IResultConverter
    {
        private readonly IMapper mapper;

        public ResultConverter()
        {
            mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile<DocumentoProfile>();
                cfg.AddProfile<TecnicoProfile>();
            }).CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = mapper.Map<T>(source);
            return model;
        }
    }
}
