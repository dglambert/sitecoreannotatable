using dglambert.SitecoreAnnotatable.Infrastructure.Markers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using System;
using System.Diagnostics.CodeAnalysis;

namespace dglambert.SitecoreAnnotatable.Tests.Markers
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AnnotatableXMLElementMarkerTests
    {
        [TestMethod]
        public void CTOR_Valid()
        {
            //Arrange
            string providedRenderingName = "I_am_a_rendering";
            string providedDataSource = null;

            //Act
            IMarker actualMarker = new AnnotatableXMLElementMarker(providedRenderingName, providedDataSource);

            //Assert
            Assert.IsNotNull(actualMarker);

        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CTOR_NullRenderingName_ThrowsException()
        {
            //Arrange
            string providedRenderingName = null;
            string providedDataSource = null;

            //Act
            _ = new AnnotatableXMLElementMarker(providedRenderingName, providedDataSource);

            //Assert

        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CTOR_EmptyWhiteSpaceRenderingName_ThrowsException()
        {
            //Arrange
            string providedRenderingName = " ";
            string providedDataSource = null;

            //Act
            _ = new AnnotatableXMLElementMarker(providedRenderingName, providedDataSource);

            //Assert
        }

        [TestMethod]
        public void GetStart_Valid_RenderingName_and_Null_Datasource()
        {
            //Arrange
            string providedRenderingName = "I_am_a_rendering";
            string providedDataSource = null;
            string expectedStartString = $"<rendering data-rendering-name=\"{providedRenderingName}\" data-data-source=\"\">";

            //Act
            IMarker actualMarker = new AnnotatableXMLElementMarker(providedRenderingName, providedDataSource);

            //Assert

            Assert.AreEqual(expectedStartString, actualMarker.GetStart());
        }

        [TestMethod]
        public void GetStart_Valid_RenderingName_and_Datasource()
        {
            //Arrange
            string providedRenderingName = "I_am_a_rendering";
            string providedDataSource = "I_am_a_datasource";
            string expectedStartString = $"<rendering data-rendering-name=\"{providedRenderingName}\" data-data-source=\"{providedDataSource}\">";

            //Act
            IMarker actualMarker = new AnnotatableXMLElementMarker(providedRenderingName, providedDataSource);

            //Assert
            Assert.AreEqual(expectedStartString, actualMarker.GetStart());
        }

        [TestMethod]
        public void GetEnd_Valid()
        {
            //Arrange
            string providedRenderingName = "I_am_a_rendering";
            string providedDataSource = null;
            string expectedStartString = $"</rendering>";

            //Act
            IMarker actualMarker = new AnnotatableXMLElementMarker(providedRenderingName, providedDataSource);

            //Assert
            Assert.AreEqual(expectedStartString, actualMarker.GetEnd());

        }
    }
}
