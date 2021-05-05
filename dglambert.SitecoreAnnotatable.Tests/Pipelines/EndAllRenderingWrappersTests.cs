using dglambert.SitecoreAnnotatable.Infrastructure.Pipelines;
using dglambert.SitecoreAnnotatable.Infrastructure.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using Sitecore.Mvc.Presentation;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace dglambert.SitecoreAnnotatable.Tests.Pipelines
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class EndAllRenderingWrappersTests
    {
        [TestMethod]
        public void Process_Valid_Args()
        {
            //Arrange
            Rendering providedRendering = new Mock<Rendering>().Object;
            TextWriter providedTextWriter = new Mock<TextWriter>().Object;
            RenderRenderingArgs providedRenderRenderingArgs = new RenderRenderingArgs(providedRendering, providedTextWriter);

            Mock<IDisposable> mockAnnotatableRenderingWrapper = new Mock<IDisposable>();
            providedRenderRenderingArgs.Disposables.Add(mockAnnotatableRenderingWrapper.Object);

            EndAllRenderingWrappers endAllRenderingWrappers = new EndAllRenderingWrappers();


            //Act
            endAllRenderingWrappers.Process(providedRenderRenderingArgs);

            //Assert
            mockAnnotatableRenderingWrapper.Verify(i => i.Dispose(), Times.Once);


        }

        
    }
}
