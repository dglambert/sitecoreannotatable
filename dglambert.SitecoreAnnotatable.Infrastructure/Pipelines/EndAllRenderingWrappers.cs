using dglambert.SitecoreAnnotatable.Infrastructure.Wrappers;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using System;
using System.Linq;


namespace dglambert.SitecoreAnnotatable.Infrastructure.Pipelines
{
    public class EndAllRenderingWrappers : RenderRenderingProcessor
    {
        public override void Process(RenderRenderingArgs args)
        {
            foreach(IDisposable wrapper in args.Disposables.OfType<IDisposable>())
            {
                wrapper.Dispose();
            }
        }
    }
}
