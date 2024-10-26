using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using HDI.Business.Abstruct;
using HDI.Business.Concreate;
using HDI.Data.Abstruct.Repositories;
using HDI.Data.Concreate.Repositories;
using HDI.Entities;
using HDI.Service.App_Start;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace HDI.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);


            #region CONTAINER (Bağımlılıklar...)

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Managers...
            builder.RegisterType<PartnerManager>().As<IPartnerManager>();
            builder.RegisterType<ProductManager>().As<IProductManager>();
            builder.RegisterType<ContractManager>().As<IContractManager>();
            builder.RegisterType<WorkManager>().As<IWorkManager>();


            //Repositories...
            builder.RegisterType<PartnerRepository>().As<IPartnerRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ContractRepository>().As<IContractRepository>();
            builder.RegisterType<WorkRepository>().As<IWorkRepository>();


            //Automapper...
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new MapProfile()); });
            var mapper = mapperConfiguration.CreateMapper();
            builder.RegisterInstance<IMapper>(mapper);


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            #endregion
        }
    }
}
