using System;
using System.Collections.Generic;
using System.Web;
using BBC.Repositories;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Rendering = Sitecore.Mvc.Presentation.Rendering;

namespace BBC.Classes
{
    public class Parameters
    {
        //field name
        public static string ColorName =>
            "ColorName";

        public static string GetBackgroundColor(Rendering rendering)
        {
            string id = rendering.Parameters[ColorName];
            var item = ItemRepository.GetItemById(id);
            Sitecore.Data.Fields.ReferenceField field = item.Fields[ColorName];
            return field.TargetItem.Name;
        }
    }
}