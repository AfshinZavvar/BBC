using System.Collections.Generic;
using BBC.Factories;
using BBC.Models;
using Glass.Mapper.Sc;
using Sitecore.Data.Items;


namespace BBC.Repositories
{
    public class NewsRepository
    {
        private ISitecoreContext Context { get; set; }

        public NewsRepository(ISitecoreContext _Context)
        {
            Context = _Context;
        }


        public  IEnumerable<INews> GetAllNews()
        {
          return  Context.Query<INews>("/sitecore/content/Home/News/*[@@templatename='News']");
        }
     }
}