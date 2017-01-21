using System.Collections.Generic;
using BBC.Models;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace BBC.ViewModels
{
    public class CategoriesViewModel
    {
        [SitecoreQuery("/sitecore/content/Home/Global/Categories/*")]
        public IEnumerable<ICategory> Categories { get; set; }
    }
}