using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookManager>().As<IBookService>();
            builder.RegisterType<AuthorManager>().As<IAuthorService>();
            builder.RegisterType<PublisherManager>().As<IPublisherService>();
            builder.RegisterType<ISBNCheckManager>().As<IISBNCheckService>();

            builder.RegisterType<EfBookDal>().As<IBookDal>();
            builder.RegisterType<EfAuthorDal>().As<IAuthorDal>();
            builder.RegisterType<EfPublisherDal>().As<IPublisherDal>();

        }
    }
}
