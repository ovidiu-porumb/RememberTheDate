using NPoco;
using NPoco.FluentMappings;

namespace OP.RememberTheDate.Storage
{
    public class StorageFactory
    {
        public static DatabaseFactory Database { get; set; }

        public static void Setup(string connectionString)
        {
            var fluentConfiguration = FluentMappingConfiguration.Configure(new DateMapping());

            Database = DatabaseFactory.Config(configurationAction => 
                configurationAction.UsingDatabase(() => new Database(connectionString))
                .WithFluentConfig(fluentConfiguration)
                );
        }
    }
}
