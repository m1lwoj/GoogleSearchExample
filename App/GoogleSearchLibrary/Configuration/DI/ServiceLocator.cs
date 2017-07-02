using GoogleSearchLibrary.Services;
using Ninject;

namespace GoogleSearchLibrary.Configuration.DI
{
    internal class ServiceLocator
    {
        private static IServiceLocator serviceLocator;

        static ServiceLocator()
        {
            serviceLocator = new DefaultServiceLocator();
        }

        public static IServiceLocator Current
        {
            get
            {
                return serviceLocator;
            }
        }

        private class DefaultServiceLocator : IServiceLocator
        {
            private readonly IKernel kernel;  

            public DefaultServiceLocator()
            {
                kernel = new StandardKernel();
                LoadBindings();
            }

            public T Get<T>()
            {
                return kernel.Get<T>();
            }

            private void LoadBindings()
            {
                kernel.Bind<IGoogleSearchAdapter>().To<GoogleSearchAdapter>().InSingletonScope();
                kernel.Bind<IConfigurationProvider>().To<JsonConfigurationProvider>().InSingletonScope();
            }
        }
    }
}
