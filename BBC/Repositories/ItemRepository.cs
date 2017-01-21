using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace BBC.Repositories
{
    public class ItemRepository
    {
        public static Item GetItemById(ID param) =>Context.Database.GetItem(param);

        public static Item GetItemById(string param) =>Context.Database.GetItem(new ID(param));
    }
}