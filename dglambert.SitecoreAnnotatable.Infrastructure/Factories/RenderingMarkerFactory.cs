using dglambert.SitecoreAnnotatable.Infrastructure.Markers;
using dglambert.SitecoreAnnotatable.Infrastructure.Queries;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using Sitecore.Mvc.Presentation;
using System;

namespace dglambert.SitecoreAnnotatable.Infrastructure.Factories
{
    public class RenderingMarkerFactory : IRenderingMarkerFactory
    {
        private readonly IGetDataSourceQuery _getDataSourceQuery;

        public RenderingMarkerFactory(IGetDataSourceQuery getDataSourceQuery)
        {
            _getDataSourceQuery = getDataSourceQuery;
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
                return _getDataSourceQuery.GetDataSourceItemPath(DataSourceID);
            }
            return dataSource;
        }
    }
}
