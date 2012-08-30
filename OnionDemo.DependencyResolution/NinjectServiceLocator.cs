using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using OnionDemo.Core;

namespace OnionDemo.DependencyResolution
{
    internal class NinjectServiceLocator : IServiceLocator
    {
        private readonly IKernel _kernel;

        public NinjectServiceLocator(IKernel kernel)
        {
            _kernel = kernel;
        }

        public T GetInstance<T>()
        {
            try
            {
                return _kernel.Get<T>();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Dependency resolution failed", ex);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public object GetInstance(Type type)
        {
            try
            {
                return _kernel.Get(type);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Dependency resolution failed", ex);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
