using dglambert.SitecoreAnnotatable.Infrastructure.Markers;
using dglambert.SitecoreAnnotatable.Infrastructure.Services;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using Sitecore.Mvc.Presentation;
using System;

namespace dglambert.SitecoreAnnotatable.Infrastructure.Factories
{
    public class RenderingMarkerFactory : IRenderingMarkerFactory
    {
        private readonly IContentService _contentService;

        public RenderingMarkerFactory(IContentService contentService)
        {
            _contentService = contentService;
        }

        public IMarker Create(Rendering rendering)
        {
            _ = rendering ?? throw new ArgumentNullException("rendering must be a non-null value.");
            string dataSource = GetDataSourceItemPath(rendering.DataSource);
            return new AnnotatableRenderingXMLElementMarker(rendering.ToString(), dataSource);
        }

        private string GetDataSourceItemPath(string dataSource)
        {
            Guid DataSourceID;
            if (Guid.TryParse(dataSource, out DataSourceID))
            {
                return _contentService.GetDataSourceItemPath(DataSourceID);
            }
            return dataSource;
        }
    }
}
