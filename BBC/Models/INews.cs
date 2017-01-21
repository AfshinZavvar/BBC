using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace BBC.Models
{
    [SitecoreType(TemplateId = "{E5E5393E-AC53-4777-BFE3-BB9E6A5D70E2}", AutoMap = true)]
    public interface INews : IContentBase
    {
        [SitecoreField]
        string Title { get; set; }

        [SitecoreField]
        string ShortDescription { get; set; }

        [SitecoreField]
        Image Logo { get; set; }

        [SitecoreField]
        string Description { get; set; }

        [SitecoreField]
        DateTime Date { get; set; }

        [SitecoreField(FieldName = "Category")]
        IEnumerable<ICategory> Categories { get; set; }

        [SitecoreChildren]
        IEnumerable<IComment> Children { get; set; }

    }
}
