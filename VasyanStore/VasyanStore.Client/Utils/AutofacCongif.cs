using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VasyanStore.Client.Controllers;
using VasyanStore.DataAccess;
using VasyanStore.DataAccess.Repository.Abstraction;
using VasyanStore.DataAccess.Repository.Implementation;
using VasyanStore.Domain.Services.Abstraction;
using VasyanStore.Domain.Services.Implementation;
using AutoMapper;

namespace VasyanStore.Client.Utils
{
    public class AutofacCongif
    {
        public static void ConfigureContainer()
        {
            //Створюємо білдер нашого контейнера
            var builder = new ContainerBuilder();

            // Ми реєструємо всі контролери в проекті
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<EFContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<GamesService>().As<IGamesService>();

            //Register AutoMapper
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            builder.RegisterInstance<IMapper>(mapperConfig.CreateMapper());

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));

            //var controller = new GamesController(new GamesService(new EfRepository<Game>(new EFContext())))
        }
    }
}