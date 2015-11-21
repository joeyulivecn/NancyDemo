using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Data
{
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
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
