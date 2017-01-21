using System;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace BBC.Models
{
    [SitecoreType(AutoMap = true)]
    public interface IContentBase
    {
        [SitecoreId]
        Guid ItemId { get;  }

        [SitecoreInfo(Type = SitecoreInfoType.Url)]
        string TemplateUrl { get;  }

        [SitecoreInfo(Type = SitecoreInfoType.TemplateId)]
        Guid TemplateId { get;  }

        [SitecoreInfo(Type = SitecoreInfoType.Key)]
        string Key { get;  }

        [SitecoreInfo(Type = SitecoreInfoType.Version)]
        int Version { get;  }
    }
}
