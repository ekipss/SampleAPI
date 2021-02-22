using Autofac;
using Newtonsoft.Json;
using SampleAPI.API.Students.Queries;
using SampleAPI.Domain.AggregatesModel.Students;
using SampleAPI.Infrastructure.Idempotency;
using SampleAPI.Infrastructure.Repositories;
using System;

namespace SampleAPI.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new StudentQueries(QueriesConnectionString))
              .As<IStudentQueries>()
              .InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>()
                .As<IStudentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RequestManager>()
               .As<IRequestManager>()
               .InstancePerLifetimeScope();

      
        }


    }
}
