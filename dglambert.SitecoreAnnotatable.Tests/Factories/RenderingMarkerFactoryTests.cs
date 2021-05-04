using dglambert.SitecoreAnnotatable.Infrastructure.Factories;
using dglambert.SitecoreAnnotatable.Infrastructure.Markers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            //Act
            RenderingMarkerFactory actualRenderingMarkerFactory = new RenderingMarkerFactory();

            //Assert
            Assert.IsNotNull(actualRenderingMarkerFactory);
        }

        [TestMethod]
        public void Create_Valid_ControllerRendering()
        {
            //Arrange
            RenderingMarkerFactory providedRenderingMarkerFactory = new RenderingMarkerFactory();
            Rendering providedRendering = new Rendering();
            providedRendering.DataSource = "thisDataSource";
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
            RenderingMarkerFactory providedRenderingMarkerFactory = new RenderingMarkerFactory();
            Rendering providedRendering = new Rendering();
            providedRendering.DataSource = "thisDataSource";
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

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Create_NullRendering_ThrowsException()
        {
            //Arrange
            RenderingMarkerFactory providedRenderingMarkerFactory = new RenderingMarkerFactory();
            Rendering providedRendering = null;

            //Act
            _ = providedRenderingMarkerFactory.Create(providedRendering);

            //Assert

        }
    }
}
