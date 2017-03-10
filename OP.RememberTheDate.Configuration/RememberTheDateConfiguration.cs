using Project.Configurations.Manager.Model;

namespace OP.RememberTheDate.Configuration
{
    public class RememberTheDateConfiguration : ConfigurationModelBase
    {
        public CommonConfigurations Common { get; set; }
        public WebServiceConfigurations WebService { get; set; }
    }
}
