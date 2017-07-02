using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace GoogleSearchLibrary.Configuration
{
    public class JsonConfigurationProvider : FileConfigurationProvider, IConfigurationProvider
    {
        private static string FileLocation = $@"{AssemblyDirectory}\Configuration.json";

        public ConfigurationModel GetConfiguration()
        {
            using (StreamReader r = File.OpenText(FileLocation))
            {
                string json = r.ReadToEnd();
                var model = JsonConvert.DeserializeObject<ConfigurationModel>(json);

                return model;
            }
        }
    }
}