using Autofac;
using SampleAPI.API.Students.Queries;

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

        }
    }
}
