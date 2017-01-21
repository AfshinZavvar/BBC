using Glass.Mapper.Sc;
using Sitecore.Configuration;
using Sitecore.Data;

namespace BBC.Factories
{
    public static class BBCFactory
    {
        public enum enumSiteCoreDataBase
        {
            Master,
            Web
        }

        //Sitecore
        public static Database GetSitecoreDatabase(enumSiteCoreDataBase database)
        {
            return Factory.GetDatabase(database.ToString().ToLower());
        }

        //Glass.Mapper
        public static ISitecoreService GetSitecoreService(enumSiteCoreDataBase database)
        {
            return new SitecoreService(database.ToString().ToLower());
        }
    }
}