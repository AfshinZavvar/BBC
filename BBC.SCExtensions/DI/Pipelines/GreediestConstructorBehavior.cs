using System;
using System.Linq;
using System.Reflection;
using SimpleInjector.Advanced;

namespace BBC.SCExtensions.DI
{
    public class GreediestConstructorBehavior : IConstructorResolutionBehavior
    {
        public ConstructorInfo GetConstructor(Type serviceType, Type implementationType)
        {
            return (
                    implementationType.GetConstructors().OrderByDescending(ctor => ctor.GetParameters().Length))
                .First();
        }
    }
}