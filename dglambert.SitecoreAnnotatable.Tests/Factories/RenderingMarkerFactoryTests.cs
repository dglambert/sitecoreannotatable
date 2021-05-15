using dglambert.SitecoreAnnotatable.Infrastructure.Factories;
using dglambert.SitecoreAnnotatable.Infrastructure.Markers;
using dglambert.SitecoreAnnotatable.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using Sitecore.Mvc.Presentation;
using System;
using System.Diagnostics.CodeAnalysis;

namespace dglambert.SitecoreAnnotatable.Tests.Factories
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class RenderingMarkerFactoryTests
    {
        [TestMethod]
        public void CTOR_Valid()
        {
            //Arrange
            IContentService providedContentService = null;

            //Act
            RenderingMarkerFactory actualRenderingMarkerFactory = new RenderingMarkerFactory(providedContentService);

            //Assert
            Assert.IsNotNull(actualRenderingMarkerFactory);
        }

        [TestMethod]
        public void Create_Valid_ControllerRendering()
        {
            //Arrange
            string providedDataSource = "thisDataSource";
            Mock<IContentService> mockContentService = new Mock<IContentService>();
            mockContentService.Setup(i => i.GetDataSourceItemPath(It.IsAny<Guid>())).Returns(providedDataSource);
            IContentService providedContentService = mockContentService.Object;
            RenderingMarkerFactory providedRenderingMarkerFactory = new RenderingMarkerFactory(providedContentService);
            Rendering providedRendering = new Rendering();
            providedRendering.DataSource = providedDataSource;
            ControllerRenderer providedRenderer = new ControllerRenderer();
            providedRenderer.ControllerName = "thisController";
            providedRenderer.ActionName = "thisAction";
            providedRendering.Renderer = providedRenderer;
            Type expectedType = typeof(AnnotatableRenderingXMLElementMarker);
            string expectedRenderingName = $"Controller: {providedRenderer.ControllerName}. Action: {providedRenderer.ActionName}";
            string expectedStartString = $"<rendering data-rendering-name=\"{expectedRenderingName}\" data-data-source=\"{providedRendering.DataSource}\">";

            //Act
            IMarker actualRenderingMarker = providedRenderingMarkerFactory.Create(providedRendering);

            //Assert
            Assert.AreEqual(expectedType, actualRenderingMarker.GetType());
            Assert.AreEqual(expectedStartString, actualRenderingMarker.GetStart());
        }

        [TestMethod]
        public void Create_Valid_ViewRendering()
        {
            //Arrange
            string providedDataSource = "thisDataSource";
            Mock<IContentService> mockContentService = new Mock<IContentService>();
            mockContentService.Setup(i => i.GetDataSourceItemPath(It.IsAny<Guid>())).Returns(providedDataSource);
            IContentService providedContentService = mockContentService.Object;
            RenderingMarkerFactory providedRenderingMarkerFactory = new RenderingMarkerFactory(providedContentService);
            Rendering providedRendering = new Rendering();
            providedRendering.DataSource = providedDataSource;
            ViewRenderer providedRenderer = new ViewRenderer();
            providedRenderer.ViewPath = "this.cshtml";
            providedRendering.Renderer = providedRenderer;
            Type expectedType = typeof(AnnotatableRenderingXMLElementMarker);
            string expectedRenderingName = $"View: {providedRenderer.ViewPath}";
            string expectedStartString = $"<rendering data-rendering-name=\"{expectedRenderingName}\" data-data-source=\"{providedRendering.DataSource}\">";

            //Act
            IMarker actualRenderingMarker = providedRenderingMarkerFactory.Create(providedRendering);

            //Assert
            Assert.AreEqual(expectedType, actualRenderingMarker.GetType());
            Assert.AreEqual(expectedStartString, actualRenderingMarker.GetStart());
        }

        [TestMethod]
        public void Create_Valid_Rendering_With_Guid_Datasource()
        {
            //Arrange
            string providedDataSource = Guid.NewGuid().ToString();
            string expectedDataSource = "Not a Guid";
            Mock<IContentService> mockContentService = new Mock<IContentService>();
            mockContentService.Setup(i => i.GetDataSourceItemPath(It.IsAny<Guid>())).Returns(expectedDataSource);
            IContentService providedContentService = mockContentService.Object;
            RenderingMarkerFactory providedRenderingMarkerFactory = new RenderingMarkerFactory(providedContentService);
            Rendering providedRendering = new Rendering();
            providedRendering.DataSource = providedDataSource;
            ViewRenderer providedRenderer = new ViewRenderer();
            providedRenderer.ViewPath = "this.cshtml";
            providedRendering.Renderer = providedRenderer;
            Type expectedType = typeof(AnnotatableRenderingXMLElementMarker);
            string expectedRenderingName = $"View: {providedRenderer.ViewPath}";
            string expectedStartString = $"<rendering data-rendering-name=\"{expectedRenderingName}\" data-data-source=\"{expectedDataSource}\">";

            //Act
            IMarker actualRenderingMarker = providedRenderingMarkerFactory.Create(providedRendering);

            //Assert
            Assert.AreEqual(expectedType, actualRenderingMarker.GetType());
            Assert.AreEqual(expectedStartString, actualRenderingMarker.GetStart());
        }


        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Create_NullRendering_ThrowsException()
        {
            //Arrange
            IContentService providedContentService = null;
            RenderingMarkerFactory providedRenderingMarkerFactory = new RenderingMarkerFactory(providedContentService);
            Rendering providedRendering = null;

            //Act
            _ = providedRenderingMarkerFactory.Create(providedRendering);

            //Assert

        }
    }
}
