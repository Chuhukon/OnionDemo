using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Onion.Infrastructure;
using OnionDemo.Core;
using OnionDemo.Core.Base;

namespace OnionDemo.DependencyResolution.Initializers
{
    public class ConsoleInitializer : IDependencyInitializer 
    {
        public void Start()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IAlbumRepository>().To<AlbumRepository>();
            kernel.Bind<IValidationDictionary>().To<Validation>();

            ServiceLocator.SetServiceLocator(() => new NinjectServiceLocator(kernel));
        }

    }
}
