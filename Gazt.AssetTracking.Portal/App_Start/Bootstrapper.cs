using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Gazt.AssetTracking.Core.Domain;
using Gazt.AssetTracking.Data;
using Gazt.AssetTracking.Data.Infrastructure;
using Gazt.AssetTracking.Data.Repositories;
using Gazt.AssetTracking.Services.Assets;
using Gazt.AssetTracking.ViewModels;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Gazt.AssetTracking.Portal.App_Start
{
    public static class Bootstrapper
    {
        public static void Run(IAppBuilder app)
        {
            SetAutofacContainer(app);
            var languageCookie =HttpContext.Current.Request.Cookies["i18n.langtag"];
            var languageValue = languageCookie != null ? languageCookie.Value : "en";
            var isArabic = !(languageValue == "en" ? false : true);


            //Configure AutoMapper
            Mapper.Initialize(cfg =>
            {
                ApplyMapping(cfg, isArabic);
            });
        }

        private static void ApplyMapping(IMapperConfiguration cfg, bool isArabic)
        {
            cfg.CreateMap<Asset, AssetViewModel>()
                            .ForMember(e => e.ZoneName, opt => opt.MapFrom(f => isArabic ? f.Zone.NameAr : f.Zone.NameEn))

                            .ForMember(e => e.ModelName, opt => opt.MapFrom(f => isArabic ? f.AssetModel.NameAr : f.AssetModel.NameEn))
                             .ForMember(e => e.LocationId, opt => opt.MapFrom(f =>f.Zone.LocationId)).ReverseMap();

            cfg.CreateMap<Location, LocationViewModel>().ForMember(e => e.Name, opt => opt.MapFrom(f => isArabic ? f.NameAr : f.NameEn)).ReverseMap();

            cfg.CreateMap<AssetModel, AssetModelViewModel>().ForMember(e => e.Name, opt => opt.MapFrom(f => isArabic ? f.NameAr : f.NameEn)).ReverseMap();



            cfg.CreateMap<Zone, ZoneViewModel>()
            .ForMember(e => e.LocationName, opt => opt.MapFrom(f => isArabic ? f.Location.NameAr : f.Location.NameEn))
            .ForMember(e => e.Name, opt => opt.MapFrom(f => isArabic ? f.NameAr : f.NameEn)).ReverseMap();
        }

        public static void Run()
        {
          
            var languageCookie = HttpContext.Current.Request.Cookies["i18n.langtag"];
            var languageValue = languageCookie != null ? languageCookie.Value : "en";
            var isArabic = !(languageValue == "en" ? false : true);


            //Configure AutoMapper
            Mapper.Initialize(cfg =>
            {
                ApplyMapping(cfg, isArabic);
            });
        }
        private static void SetAutofacContainer(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationContext>().AsSelf().InstancePerRequest();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly)
                .AsImplementedInterfaces();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(AssetRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(AssetService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();


            builder.RegisterType<ApplicationContext>().As<IDbContext>().InstancePerRequest();

            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User, int>>().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();


            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // Register with Owin
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}