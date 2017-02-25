using System.Collections.Generic;
using BBC.Factories;
using BBC.Models;
using Glass.Mapper.Sc;
using Sitecore.Data.Items;


namespace BBC.Repositories
{
    public class NewsRepository
    {

        public static Item GetNewsRoot()
        {
            return
                BBCFactory.GetSitecoreDatabase(BBCFactory.enumSiteCoreDataBase.Web)
                    .GetItem("/sitecore/content/Home/News");
        }



        public static IEnumerable<INews> GetNews() =>
            BBCFactory.GetSitecoreService(BBCFactory.enumSiteCoreDataBase.Web)
                .Query<INews>("/sitecore/content/Home/News/*[@@templatename='News']");
    }
}