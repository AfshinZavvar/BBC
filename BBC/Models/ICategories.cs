using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.IoC;


namespace BBC.Models
{
    [SitecoreType(TemplateId = "{F568E137-F19F-4471-BC2F-ACEAB5A4DDBF}", AutoMap = true)]

    public interface ICategories :IContentBase
    {
        [SitecoreChildren]
        IEnumerable<ICategory> Children { get; set; }

    }
}