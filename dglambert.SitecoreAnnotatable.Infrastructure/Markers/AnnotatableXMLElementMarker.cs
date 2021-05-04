using Sitecore.Mvc.ExperienceEditor.Presentation;
using System;

namespace dglambert.SitecoreAnnotatable.Infrastructure.Markers
{
    public class AnnotatableXMLElementMarker : IMarker
    {
        string _renderingName;
        string _dataSource;

        public AnnotatableXMLElementMarker(string renderingName, string dataSource = "")
        {
            _renderingName = renderingName ?? throw new ArgumentNullException("renderingName must be a non-null value.");
            _renderingName = renderingName.Trim().Length > 0 ? renderingName : throw new ArgumentException("renderingName must be a non-whitespace value.");
            _dataSource = dataSource;
        }

        public string GetStart()
        {
            return $"<rendering data-rendering-name=\"{_renderingName}\" data-data-source=\"{_dataSource}\">";
        }

        public string GetEnd()
        {
            return "</rendering>";
        }
    }
}
