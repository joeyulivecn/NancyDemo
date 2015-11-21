using Nancy;
using Nancy.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Authentication.Token;
using Autofac;
using Nancy.Bootstrappers.Autofac;
using System.Reflection;
using NLog;

namespace NancyDemo
{
    public class CustomBootstrapper : AutofacNancyBootstrapper
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // No registrations should be performed in here, however you may
        // resolve things that are needed during application startup.
        protected override void ApplicationStartup(ILifetimeScope container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            _logger.Debug("ApplicationStartup");

            base.ApplicationStartup(container, pipelines);
        }

        // Perform registration that should have an application lifetime
        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            _logger.Debug("ConfigureApplicationContainer");

            base.ConfigureApplicationContainer(existingContainer);

            //When using assembly scanning with IIS applications, you can run into a little trouble depending on how you do the assembly location. (This is one of our FAQs)

            //When hosting applications in IIS all assemblies are loaded into the AppDomain when the application first starts, but when the AppDomain is recycled by IIS the assemblies are then only loaded on demand.

            //To avoid this issue use the GetReferencedAssemblies() method on System.Web.Compilation.BuildManager to get a list of the referenced assemblies instead:
            //var assemblies = System.Web.Compilation.BuildManager.GetReferencedAssemblies().Cast<Assembly>();

            var asms = AppDomain.CurrentDomain.GetAssemblies();
            //.Where(asm =>asm.GetCustomAttributes().Any(attr => attr.GetType() == typeof(IncludeInNancyAssemblyScanningAttribute)));

            var builder = new ContainerBuilder();
            //foreach (var asm in asms)
            //{
            //    builder.RegisterAssemblyTypes(asm).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            //}
            builder.RegisterModule<Nancy.Demo.Data.DataModule>();
            builder.RegisterModule<NancyDemo.Services.ServiceModule>();

            builder.RegisterType<Tokenizer>().As<ITokenizer>();

            builder.Update(existingContainer.ComponentRegistry);
        }

        // Perform registrations that should have a request lifetime
        protected override void ConfigureRequestContainer(ILifetimeScope container, NancyContext context)
        {
            _logger.Debug("ConfigureRequestContainer");
            base.ConfigureRequestContainer(container, context);
        }

        // No registrations should be performed in here, however you may
        // resolve things that are needed during request startup.
        protected override void RequestStartup(ILifetimeScope container, Nancy.Bootstrapper.IPipelines pipelines, NancyContext context)
        {
            _logger.Debug("RequestStartup");
            base.RequestStartup(container, pipelines, context);
            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));
        }

        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get { return new DiagnosticsConfiguration { Password = @"A2\6mVtH/XRT\p,B" }; }
        }
    }
}