using dglambert.SitecoreAnnotatable.Infrastructure.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace dglambert.SitecoreAnnotatable.Tests.Wrappers
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AnnotatableRenderingWrapperTests
    {
        [TestMethod]
        public void CTOR_Valid()
        {
            //Arrange
            TextWriter providedTextWriter = new Mock<TextWriter>().Object;
            IMarker providedMarker = new Mock<IMarker>().Object;

            //Act
            AnnotatableRenderingWrapper actualAnnotatableRenderingWrapper = new AnnotatableRenderingWrapper(providedTextWriter, providedMarker);

            //Assert
            Assert.IsNotNull(actualAnnotatableRenderingWrapper);
        }
    }
}
