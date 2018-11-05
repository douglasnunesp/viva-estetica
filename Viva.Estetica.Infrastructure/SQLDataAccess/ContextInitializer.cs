using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viva.Estetica.Domain.Tecnicos;

namespace Viva.Estetica.Infrastructure.SQLDataAccess
{
    public class ContextInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            var servicos = new List<Domain.Servicos.Servico>();

            servicos.Add(new Domain.Servicos.Servico()
            {
                Nome = "Massagem",
                Duracao = new TimeSpan(0, 30, 0),
                TempoCancelamento = 1440,
            });

            servicos.Add(new Domain.Servicos.Servico()
            {
                Nome = "Massagem",
                Duracao = new TimeSpan(1, 0, 0),
                TempoCancelamento = 1440,
            });

            context.Servicos.AddRange(servicos);
            context.SaveChanges();

        }
    }
}
