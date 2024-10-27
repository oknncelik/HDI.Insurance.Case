using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using HDI.Business.Abstruct;
using HDI.Business.Concreate;
using HDI.Data.Abstruct.Repositories;
using HDI.Data.Concreate.Repositories;
using HDI.Entities;
using HDI.Partner.Integration.Concreate;
using HDI.Partner.WCF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace HDI.Partner.UI
{
    public class MvcApplication : System.Web.HttpApplication
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
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            //burda bi ismlendirme kazası oldu...
            builder.RegisterType<HDI.Partner.WCF.Service.PartnerService>().As<HDI.Partner.WCF.Service.IPartnerService>();
            builder.RegisterType<HDI.Partner.Integration.Concreate.PartnerService>().As<HDI.Partner.Integration.Abstruct.IPartnerService>();

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

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            #endregion
        }
    }
}
