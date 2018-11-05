using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Application.Repositorios.Tecnicos;
using Viva.Estetica.Domain.Tecnicos;

namespace Viva.Estetica.Infrastructure.SQLDataAccess.Respositorios
{
    public class TecnicosRepositorio : ITecnicoLeituraRepositorio, ITecnicoEscritaRepositorio
    {
        public void Adiciona(Tecnico tecnico)
        {
            using(Context context = new Context())
            {
                context.Tecnicos.Add(tecnico);
                context.SaveChanges();
            }
        }

        public void Atualiza(Tecnico tecnico)
        {
            using (Context context = new Context())
            {
                var resultado = context.Tecnicos.Single(x => x.Id == tecnico.Id);
                resultado = tecnico;
                context.SaveChanges();
            }
        }

        public void Deleta(Guid id)
        {
            using (Context context = new Context())
            {
                var resultado = context.Tecnicos.Single(x => x.Id == id);
                context.Tecnicos.Remove(resultado);
                context.SaveChanges();
            }
        }

        public Tecnico TecnicoId(Guid id)
        {
            using (Context context = new Context())
            {
                return context.Tecnicos.Single(x => x.Id == id);
            }
        }

        public List<Tecnico> Tecnicos()
        {
            using (Context context = new Context())
            {
                return context.Tecnicos.ToList();
            }
        }

        public List<Tecnico> TecnicoServico(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
