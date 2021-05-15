using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using Sitecore.Data;
using dglambert.SitecoreAnnotatable.Infrastructure.Services;
using Moq;

namespace dglambert.SitecoreAnnotatable.Tests.Services
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ContentServiceTests
    {
        [TestMethod]
        public void CTOR_Valid()
        {
            //Arrange
            Mock<Database> mockDB = new Mock<Database>();
            Database providedDatabase = mockDB.Object;

            //Act
            IContentService actualContentService = new ContentService(providedDatabase);

            //Assert
            Assert.IsNotNull(actualContentService);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CTOR_NullDatabase_ThrowsException()
        {
            //Arrange
            Database providedDatabase = null;
            
            //Act
            IContentService actualContentService = new ContentService(providedDatabase);

            //Assert
            Assert.IsNotNull(actualContentService);
        }
    }
}
