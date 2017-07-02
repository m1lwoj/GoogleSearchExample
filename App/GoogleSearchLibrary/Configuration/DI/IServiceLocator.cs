using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleSearchLibrary.Configuration.DI
{
    internal interface IServiceLocator
    {
        T Get<T>();
    }
}
