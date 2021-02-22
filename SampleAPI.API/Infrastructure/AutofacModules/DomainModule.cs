using Autofac;
using SampleAPI.API.Students.DomainServices;
using SampleAPI.Domain.AggregatesModel.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.API.Infrastructure.AutofacModules
{
    public class DomainModule : Module
    {
        public string QueriesConnectionString { get; }

        public DomainModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new StudentUniquenessChecker(QueriesConnectionString))
                     .As<IStudentUniquenessChecker>()
                     .InstancePerLifetimeScope();
        }
    }
}
