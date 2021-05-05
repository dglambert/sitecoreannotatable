using dglambert.SitecoreAnnotatable.Infrastructure.Factories;
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
    public class AddAnnotatableRenderingWrapperTests
    {
        [TestMethod]
        public void CTOR_Valid()
        {
            //Arrange
            IRenderingMarkerFactory providedRenderingMarkerFactory = null;

            //Act
            AddAnnotatableRenderingWrapper actualAddAnnotatableRenderingWrapper = new AddAnnotatableRenderingWrapper(providedRenderingMarkerFactory);

            //Assert
            Assert.IsNotNull(actualAddAnnotatableRenderingWrapper);
        }

        [TestMethod]
        public void Process_Adds_One_RenderRenderingArgs_To_Disposable()
        {
            //Arrange
            Rendering providedRendering = new Mock<Rendering>().Object;
            TextWriter providedTextWriter = new Mock<TextWriter>().Object;
            RenderRenderingArgs providedRenderRenderingArgs = new RenderRenderingArgs(providedRendering, providedTextWriter);
            IMarker returnedMarker = new Mock<IMarker>().Object;

            Mock<IRenderingMarkerFactory> mockRenderingMarkerFactory = new Mock<IRenderingMarkerFactory>();
            mockRenderingMarkerFactory.Setup(i => i.Create(It.IsAny<Rendering>())).Returns(returnedMarker);
            
            AddAnnotatableRenderingWrapper addAnnotatableRenderingWrapper = new AddAnnotatableRenderingWrapper(mockRenderingMarkerFactory.Object);
            int expectedDisposableCount = providedRenderRenderingArgs.Disposables.Count + 1;

            //Act
            addAnnotatableRenderingWrapper.Process(providedRenderRenderingArgs);

            //Assert
            Assert.AreEqual(expectedDisposableCount, providedRenderRenderingArgs.Disposables.Count);

        }
    }
}
