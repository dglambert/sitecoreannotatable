using Sitecore.Mvc.ExperienceEditor.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dglambert.SitecoreAnnotatable.Infrastructure.Markers
{
    public abstract class RenderingMarker : IMarker
    {
        protected string _renderingName;
        protected string _dataSource;

        public abstract string GetEnd();
        public abstract string GetStart();
    }
}
