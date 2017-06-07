using NPoco;
using NPoco.FluentMappings;

// ReSharper disable ClassNeverInstantiated.Global

namespace OP.RememberTheDate.Storage.SQL
{
    public class StorageFactory
    {
        public static DatabaseFactory Database { get; private set; }

        public static void Setup(string connectionString)
        {
            var fluentConfiguration = FluentMappingConfiguration.Configure(new DateMapping());

            Database = DatabaseFactory.Config(configurationAction => 
                configurationAction.UsingDatabase(() => new Database(connectionString, DatabaseType.SqlServer2012))
                .WithFluentConfig(fluentConfiguration)
                );
        }
    }
}
