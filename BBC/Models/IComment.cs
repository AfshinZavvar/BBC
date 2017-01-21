using System;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace BBC.Models
{
    [SitecoreType(TemplateId = "{32C48D2B-82ED-49B6-9774-E8D19944E308}", AutoMap = true)]
    public interface IComment 
    {
        [SitecoreField]
        string Description { get; set; }

        [SitecoreField]
        string FullName { get; set; }

        //for creating new comment, glass mapper needs Name property
        string Name { get; set; }
    }

    [SitecoreType(TemplateId = "{32C48D2B-82ED-49B6-9774-E8D19944E308}", AutoMap = true)]

    public class Comment : IComment
    {
        public string Description { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        //public Guid ItemId { get; set; }
        //public string TemplateUrl { get; set; }
        //public Guid TemplateId { get; set; }
        //public string Key { get; set; }
        //public int Version { get; set; }
    }
}