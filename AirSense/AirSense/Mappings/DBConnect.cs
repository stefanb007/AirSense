using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using AirSense.Models;

namespace AirSense.Mappings
{
    public class DBConnect
    {
        public static ISession OpenUserSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(@"Data Source=BALTOV-PC;Database=KI_Proekt;Integrated Security=True;")
                              .ShowSql()
                )
               .Mappings(m => m.FluentMappings
                              .AddFromAssemblyOf<UserViewModel>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}