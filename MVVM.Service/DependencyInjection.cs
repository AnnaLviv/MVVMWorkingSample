using Microsoft.Extensions.DependencyInjection;
using MVVM.Core;
using System;

namespace MVVM.Service
{
    public  class DependencyInjection
    {
        private readonly IServiceCollection serviceCollection = new ServiceCollection();
        private readonly IServiceProvider serviceProvider;
        public DependencyInjection()
        {
            serviceCollection.AddSingleton<IOwnerInfoService, OwnerInfoService>();
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public T GetService<T>() => serviceProvider.GetService<T>();
    }
}
