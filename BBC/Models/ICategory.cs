using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.IoC;

namespace BBC.Models
{
    [SitecoreType(TemplateId = "{6A4FE647-639C-4DC2-8A4C-7543A67080E1}", AutoMap = true)]
    public interface ICategory : IContentBase
    {
        [SitecoreField]
        string CategoryName { get; }
    }   
}