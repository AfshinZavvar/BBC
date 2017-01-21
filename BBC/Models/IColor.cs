using Glass.Mapper.Sc.Configuration.Attributes;

namespace BBC.Models
{
    [SitecoreType(TemplateId = "{55DB8F6A-807D-48F8-A3D1-D81037938F13}", AutoMap = true)]
    public interface IColor:IContentBase
    {
        string ColorName { get; set; }
    }
}