using Autofac;
using Nancy.Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Services
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(ServiceModule).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .OnActivated(arg =>
                {

                })
                .OnRelease(obj =>
                {

                });

            builder.RegisterAssemblyTypes(typeof(TestDbContext).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsSelf()
                .OnActivated(arg =>
                {

                })
                .OnRelease(obj =>
                {

                });

            builder.RegisterType(typeof(TestDbContext)).AsSelf().SingleInstance();
        }
    }
}
