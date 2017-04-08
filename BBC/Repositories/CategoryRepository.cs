using System;
using System.Collections.Generic;
using System.Linq;
using BBC.Factories;
using BBC.Models;
using Glass.Mapper.Sc;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace BBC.Repositories
{
    public class CategoryRepository
    {
        #region fields

        private ISitecoreContext Context { get; set; }
        private NewsRepository NewsRepository { get; set; }

        #endregion

        public CategoryRepository(ISitecoreContext _Context, NewsRepository _NewsRepository)
        {
            Context = _Context;
            NewsRepository = _NewsRepository;
        }

        public IEnumerable<INews> GetNewsOfCategory(ICategory category)
        {
            Guid categoryId = category.ItemId;

            return NewsRepository.GetAllNews().Where(x => x.Categories.Any(y => y.ItemId == categoryId));
        }

        //Work with sitecore built-in APIs
        public IEnumerable<Item> GetNewsOfCategory()
        {
            var flag = false;
            var itemId = Sitecore.Context.Item.ID;
            var source = new List<Item>();
            Item[] allNews = BBCFactory.GetSitecoreDatabase(BBCFactory.enumSiteCoreDataBase.Web)
                .SelectItems("/sitecore/content/Home/News/*[@@templatename='News']");
            foreach (var news in allNews)
            {
                MultilistField refMultilistField = news.Fields["Category"];
                var items = refMultilistField.GetItems();
                foreach (var t in items)
                    if (t.ID == itemId) flag = true;
                if (flag)
                {
                    source.Add(news);
                    flag = false;
                }
            }
            return source.AsEnumerable();
        }
    }
}