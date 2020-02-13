using Autofac;
using Autofac.Features.ResolveAnything;
using KtpAcsMiddleware.Domain.Base;
using KtpAcsMiddleware.Domain.Teams;

namespace KtpAcsMiddleware.Init
{
    public class DataFactory
    {
        static DataFactory()
        {
            DataObjectMapConfig.Configure();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            containerBuilder.RegisterModule(new DataModule());
            using (var container = containerBuilder.Build())
            {
                TeamWorkTypeRepository = container.Resolve<ITeamWorkTypeRepository>();
            }
        }

        internal static ITeamWorkTypeRepository TeamWorkTypeRepository { get; }
    }
}