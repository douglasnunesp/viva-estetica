using Autofac;
using Viva.Estetica.Application.Comandos.Agenda.Atualiza;
using Viva.Estetica.Application.Comandos.Agenda.Marca;
using Viva.Estetica.Application.Comandos.Agenda.Remove;
using Viva.Estetica.Application.Comandos.Autenticacao;
using Viva.Estetica.Application.Comandos.Cliente.Adiciona;
using Viva.Estetica.Application.Comandos.Cliente.Atualiza;
using Viva.Estetica.Application.Comandos.Tecnicos.Adicionar;
using Viva.Estetica.Application.Comandos.Tecnicos.Seleciona;
using Viva.Estetica.Application.Repositorios.Tecnicos;
using Viva.Estetica.Infrastructure.Mapeamentos;
using Viva.Estetica.Infrastructure.SQLDataAccess;
using Viva.Estetica.Infrastructure.SQLDataAccess.Respositorios;

namespace Viva.Estetica.Infrastructure.Modulos
{
    public class InfrastuctureModulo : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdicionarTecnicoServico>().As<IAdicionarTecnicoServico>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<SelecionaTecnicoServico>().As<ISelecionaTecnicoServico>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<AutenticacaoServico>().As<IAutenticacaoServico>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<ClienteAdicionaServico>().As<IClienteAdicionaServico>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<ClienteAtualizaServico>().As<IClienteAtualizaServico>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<AgendaMarcaServico>().As<IAgendaMarcaServico>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<AgendaAtualizaServico>().As<IAgendaAtualizaServico>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<AgendaRemoveServico>().As<IAgendaRemoveServico>().SingleInstance().PreserveExistingDefaults();
            


            builder.RegisterType<Context>().As<Context>().SingleInstance();
            builder.RegisterAssemblyTypes(typeof(ResultConverter).Assembly)
               .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
