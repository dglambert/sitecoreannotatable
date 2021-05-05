using dglambert.SitecoreAnnotatable.Infrastructure.Factories;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dglambert.SitecoreAnnotatable.Infrastructure.Wrappers
{
    public class AddAnnotatableRenderingWrapper : RenderRenderingProcessor
    {
        IRenderingMarkerFactory _renderingMarkerFactory;
        public AddAnnotatableRenderingWrapper(IRenderingMarkerFactory renderingMarkerFactory)
        {
            _renderingMarkerFactory = renderingMarkerFactory;
        }

        public override void Process(RenderRenderingArgs args)
        {
            IMarker marker = _renderingMarkerFactory.Create(args.Rendering);
            args.Disposables.Add(new AnnotatableRenderingWrapper(args.Writer, marker));
        }
    }
}
