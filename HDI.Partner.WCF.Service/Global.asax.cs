using Autofac;
using Autofac.Integration.Wcf;
using AutoMapper;
using HDI.Business.Abstruct;
using HDI.Business.Concreate;
using HDI.Data.Abstruct.Repositories;
using HDI.Data.Concreate.Repositories;
using HDI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace HDI.Partner.WCF.Service
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            #region CONTAINER (Bağımlılıklar...)

            var builder = new ContainerBuilder();

            builder.RegisterType<PartnerService>().As<IPartnerService>();

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

            AutofacHostFactory.Container = container;

            #endregion
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}