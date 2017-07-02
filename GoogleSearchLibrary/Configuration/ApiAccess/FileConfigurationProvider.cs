using System;
using System.IO;
using System.Reflection;

namespace GoogleSearchLibrary.Configuration
{
    public abstract class FileConfigurationProvider
    {
        protected static string AssemblyDirectory
        {
            get
            {
                string codeBase = typeof(FileConfigurationProvider).GetTypeInfo().Assembly.Location;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
