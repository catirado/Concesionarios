using Concesionarios.Domain.Repositories;
using Concesionarios.Framework.Domain;
using Concesionarios.Infrastructure.Data.EF;
using Concesionarios.Infrastructure.Data.EF.Helpers.Implementations;
using Concesionarios.Infrastructure.Data.EF.Implementations;
using Concesionarios.Infrastructure.Data.EF.Interfaces;
using Concesionarios.Infrastructure.Data.EF.Repositories;
using Concesionarios.Services;
using Concesionarios.Services.Contracts;
using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Concesionarios.UI.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var ambientDbLocater = new AmbientDbContextLocator();

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();

            container.Register<IAmbientDbContextLocator, AmbientDbContextLocator>(Lifestyle.Singleton);
            container.Register<IUnitOfWork>(() => new EFUnitOfWork(), Lifestyle.Scoped);

            container.Register<IUnitOfWorkFactory>(
                () => new EFUnitOfWorkFactory(System.Data.IsolationLevel.ReadUncommitted));

            container.Register<IClienteRepository, ClienteRepository>();

            container.Register<IClientesService, ClientesService>();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
