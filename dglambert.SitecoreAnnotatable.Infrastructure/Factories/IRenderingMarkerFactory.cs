using Sitecore.Mvc.ExperienceEditor.Presentation;
using Sitecore.Mvc.Presentation;

namespace dglambert.SitecoreAnnotatable.Infrastructure.Factories
{
    public interface IRenderingMarkerFactory
    {
        IMarker Create(Rendering rendering);
    }
}
