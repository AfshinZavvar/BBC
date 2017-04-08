using Sitecore.Pipelines;
using System;
using System.Linq;
using System.Web.Mvc;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.Web;
using SimpleInjector;

namespace BBC.SCExtensions.DI.Pipelines
{
    public class InitializeSimpleInjectorControllerFactory
    {
        public virtual void Process(PipelineArgs args)
        {
            SetControllerFactory(args);
        }

        private void SetControllerFactory(PipelineArgs args)
        {
            ContainerManager containerM = new ContainerManager();
            SetContainerOptions(containerM.Container);

            PackageExtensions.RegisterPackages(containerM.Container,
                AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("BBC")));

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(containerM.Container));
        }

        private void SetContainerOptions(Container container)
        {
            container.Options.ConstructorResolutionBehavior = new GreediestConstructorBehavior();
            container.Options.PropertySelectionBehavior = new ImportAttributePropertySelectionBehavior();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.RegisterMvcIntegratedFilterProvider();
            container.Options.AllowOverridingRegistrations = true;
            //we do not want overriding registrations but if you do this is the property you set
        }
    }
}
