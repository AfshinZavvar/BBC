using SimpleInjector.Advanced;
using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel.Composition;
namespace BBC.SCExtensions.DI
{
    public class ImportAttributePropertySelectionBehavior : IPropertySelectionBehavior
    {
        public bool SelectProperty(Type serviceType, PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes(typeof(ImportAttribute), true).Any();
        }
    }
}
