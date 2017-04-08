using BBC.Classes;
using BBC.Models;
using BBC.Pipelines;
using BBC.Repositories;
using BBC.ViewModels;
using Glass.Mapper.Sc;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace BBC.App_Start
{

    public class SimpleInjector : IPackage
    {

        public void RegisterServices(Container container)
        {
            container.Register<ISitecoreContext>(() => new SitecoreContext(), Lifestyle.Singleton);
            container.Register<IComment, Comment>(Lifestyle.Scoped);
            container.Register<CommentsViewModel>(() => new CommentsViewModel(), Lifestyle.Scoped);
            container.Register<DatePipeline>(() => new DatePipeline(), Lifestyle.Scoped);
            container.Register<NewsRepository>(Lifestyle.Scoped);
            container.Register<CategoryRepository>(Lifestyle.Scoped);
        }
    }
}