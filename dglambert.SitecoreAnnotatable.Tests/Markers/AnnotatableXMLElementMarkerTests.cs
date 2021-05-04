using dglambert.SitecoreAnnotatable.Infrastructure.Markers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using System;

namespace dglambert.SitecoreAnnotatable.Tests.Markers
{
    [TestClass]
    public class AnnotatableXMLElementMarkerTests
    {
        [TestMethod]
        public void CTOR_Valid()
        {
            //Arrange
            string providedRenderingName = "";
            string providedDataSource = null;

            //Act
            IMarker actualMarker = new AnnotatableXMLElementMarker(providedRenderingName, providedDataSource);

            //Assert
            Assert.IsNotNull(actualMarker);

        }
    }
}
