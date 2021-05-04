using dglambert.SitecoreAnnotatable.Infrastructure.Markers;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using Sitecore.Mvc.Presentation;
using System;

namespace dglambert.SitecoreAnnotatable.Infrastructure.Factories
{
    public class RenderingMarkerFactory : IRenderingMarkerFactory
    {
        public RenderingMarkerFactory()
        {

        }

        public IMarker Create(Rendering rendering)
        {
            _ = rendering ?? throw new ArgumentNullException("rendering must be a non-null value.");
            string dataSource = rendering.DataSource;
            return new AnnotatableRenderingXMLElementMarker(rendering.ToString(), dataSource);
        }
    }
}
