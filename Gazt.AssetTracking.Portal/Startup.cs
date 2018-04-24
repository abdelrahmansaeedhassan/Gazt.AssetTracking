using System;
using System.Web;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;

using Gazt.AssetTracking.Data;
using Gazt.AssetTracking.Core.Domain;

using AutoMapper;

using Gazt.AssetTracking.Data.Infrastructure;
using Gazt.AssetTracking.Portal.Controllers;
using Gazt.AssetTracking.Data.Repositories;
using Gazt.AssetTracking.Portal.App_Start;

[assembly: OwinStartupAttribute(typeof(Gazt.AssetTracking.Portal.Startup))]
namespace Gazt.AssetTracking.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Bootstrapper.Run(app);
            ConfigureAuth(app);
        }
    }
}
