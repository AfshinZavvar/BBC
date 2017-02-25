using Glass.Mapper.Sc;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace BBC.App_Start
{


    public class SimpleInjector : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<SitecoreContext>(() => new SitecoreContext(), Lifestyle.Scoped);
            container.Register(() => new Container(), Lifestyle.Singleton);
        }
    }
}