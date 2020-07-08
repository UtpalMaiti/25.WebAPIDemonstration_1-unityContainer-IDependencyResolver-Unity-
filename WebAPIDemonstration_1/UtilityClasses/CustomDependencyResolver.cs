using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;
using WebAPIDemonstration_1.Contracts;
using WebAPIDemonstration_1.Models;

namespace WebAPIDemonstration_1.UtilityClasses
{
    public class CustomDependencyResolver : IDependencyResolver
    {
        private readonly UnityContainer unityContainer;

        public CustomDependencyResolver()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            //unityContainer.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return unityContainer.Resolve(serviceType);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return unityContainer.ResolveAll(serviceType);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
    }
}