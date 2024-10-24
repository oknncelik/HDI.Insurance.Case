using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Autofac;
using System.Web.Http;
using System.Web.Mvc;
using HDI.Business.Abstruct;
using HDI.Business.Concreate;
using Autofac.Core;
using System.Reflection;
using Autofac.Features.ResolveAnything;
using AutoMapper;
using HDI.Data.Abstruct.Repositories;
using HDI.Data.Concreate.Repositories;
using HDI.Entities.Abstruct;
using HDI.Entities.Entities;
using HDI.Entities.DTOs;
using HDI.Entities;

namespace HDI.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterType<PartnerManager>().As<IPartnerManager>();
            builder.RegisterType<PartnerRepository>().As<IPartnerRepository>();

            #region MAPPING

            // 1 - Mapper configuration is done here
            // Notice the AutoMapperProfile instantiation
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new MapProfile()); });

            // 2 - After configuring the mapper, you create it
            var mapper = mapperConfiguration.CreateMapper();

            // 3 - Register that instance of the mapper, which implements IMapper interface
            builder.RegisterInstance<IMapper>(mapper);


            #endregion

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }
}
