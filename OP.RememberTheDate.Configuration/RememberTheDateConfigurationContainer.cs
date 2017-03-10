using System;
using System.IO;
using Project.Configurations.Manager;

namespace OP.RememberTheDate.Configuration
{
    public static class RememberTheDateConfigurationContainer
    {
        public static RememberTheDateConfiguration Get()
        {
            if (ProjectConfiguration<RememberTheDateConfiguration>.Data == null)
            {
                if (AppDomain.CurrentDomain.BaseDirectory.Contains("\\bin") == false)
                {
                    var configurationFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin",
                        "ConfigurationFiles\\Configuration.json");
                    var environmentsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin",
                        "ConfigurationFiles\\Environments.json");
                    ProjectConfiguration<RememberTheDateConfiguration>.Load(configurationFilePath, environmentsFilePath);
                }
                else
                {
                    var configurationFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConfigurationFiles\\Configuration.json");
                    var environmentsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConfigurationFiles\\Environments.json");
                    ProjectConfiguration<RememberTheDateConfiguration>.Load(configurationFilePath, environmentsFilePath);
                }
            }

            return ProjectConfiguration<RememberTheDateConfiguration>.Data;
        }
    }
}
