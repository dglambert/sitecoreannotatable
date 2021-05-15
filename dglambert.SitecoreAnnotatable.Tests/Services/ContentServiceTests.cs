using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using Sitecore.Data;
using dglambert.SitecoreAnnotatable.Infrastructure.Services;
using Moq;
using Sitecore.Data.Items;
using Sitecore.Globalization;

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

        [TestMethod]
        public void GetDataSourceItemPath_ValidGuid_ReturnsItemPath()
        {
            //Arrange
            var id = ID.NewID;
            var templateId = ID.NewID;
            var def = new ItemDefinition(id, "fake", templateId, ID.Null);
            var data = new ItemData(def, Language.Parse("en"), new Sitecore.Data.Version(1), new FieldList());

            Mock<Database> mockDB = new Mock<Database>();
            Database providedDatabase = mockDB.Object;


            Mock<Item> mockItem = new Mock<Item>(id, data, providedDatabase);
            Item providedItem = mockItem.Object;

            string expectedItemPath = "expectedItemPath";
            Mock<ItemPath> mockItemPath = new Mock<ItemPath>(providedItem);
            mockItemPath.Setup(i => i.FullPath).Returns(expectedItemPath);

            mockItem.Setup(i => i.Paths).Returns(mockItemPath.Object);

            mockDB.Setup(i => i.GetItem(It.IsAny<ID>())).Returns(providedItem);
            
            IContentService providedContentService = new ContentService(providedDatabase);

            //Act
            string actualItemPath = providedContentService.GetDataSourceItemPath(Guid.NewGuid());

            //Assert
            Assert.AreEqual(expectedItemPath, actualItemPath);
        }

        [TestMethod]
        public void GetDataSourceItemPath_Guid_Not_Found_ReturnsNull()
        {
            //Arrange
            Mock<Database> mockDB = new Mock<Database>();
            Database providedDatabase = mockDB.Object;

            Item providedItem = null;
            string expectedItemPath = null;

            mockDB.Setup(i => i.GetItem(It.IsAny<ID>())).Returns(providedItem);

            IContentService providedContentService = new ContentService(providedDatabase);

            //Act
            string actualItemPath = providedContentService.GetDataSourceItemPath(Guid.NewGuid());

            //Assert
            Assert.AreEqual(expectedItemPath, actualItemPath);
        }
    }
}
