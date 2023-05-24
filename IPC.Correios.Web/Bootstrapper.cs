using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using IPC.Correios.Core.Services;
using IPC.Correios.Core.Services.Interfaces;
using IPC.Correios.Core.Services.Implementations;
using IPC.Correios.Core.Repositories.Interfaces;
using IPC.Correios.Core.Repositories.Implementations;

namespace IPC.Correios.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IEnderecoService, EnderecoService>();
            container.RegisterType<IMunicipioRepository, MunicipioRepository>();
            container.RegisterType<ILogradouroRepository, LogradouroRepository>();

            return container;
        }
    }
}