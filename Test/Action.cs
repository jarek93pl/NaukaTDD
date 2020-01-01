using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentArchive.Logic.Implementation.Action;
using I = DocumentArchive.Logic.Interfaces;
using Moq;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Test
{
    [TestClass]
    public class Action
    {
        [TestMethod]
        public void AddAutorCorrect()
        {
            Autor AddingAutor = new Autor()
            {
                FirstName = "Jarek",
                LastName = "Gos³awski"
            };
            Mock<I.DB.IAddAutor> mockDb = new Mock<I.DB.IAddAutor>();
            mockDb.Setup(x => x.Action(It.IsAny<Autor>())).Returns(AddingAutor.LoadWithId(1));
            Mock<I.ILog> mockLog = new Mock<I.ILog>();
            I.Action.IAddAutor addAutor = new AddAutor(mockDb.Object, mockLog.Object);

            var result = addAutor.Action(AddingAutor);

            mockDb.Verify(X => X.Action(It.IsAny<Autor>()));
            mockLog.Verify(X => X.CatchError(It.IsAny<Exception>(), It.IsAny<object>()), Times.Never, "nie powino zg³oœiæ b³êdu");
            Assert.AreEqual(result.LastName, AddingAutor.LastName);
            Assert.AreEqual(result.FirstName, AddingAutor.FirstName);
            Assert.IsFalse(result.Id == 0);
        }

        [TestMethod]
        public void AddAutorError()
        {
            Autor AddingAutor = new Autor()
            {
                FirstName = "Jarek",
                LastName = "Gos³awski"
            };
            Mock<I.DB.IAddAutor> mockDb = new Mock<I.DB.IAddAutor>();
            mockDb.Setup(x => x.Action(It.IsAny<Autor>())).Throws(new NotImplementedException());
            Mock<I.ILog> mockLog = new Mock<I.ILog>();
            I.Action.IAddAutor addAutor = new AddAutor(mockDb.Object, mockLog.Object);

            var result = addAutor.Action(AddingAutor);

            mockDb.Verify(X => X.Action(It.IsAny<Autor>()));
            mockLog.Verify(X => X.CatchError(It.IsAny<Exception>(), It.IsAny<object>()), "nie powino zg³oœiæ b³êdu");
            Assert.IsTrue(result == null);
        }
        [TestMethod]
        public void AddCategoryCorrect()
        {
            Category category = new Category()
            {
                Name = "piwa"
            };
            Mock<I.ILog> mockLog = new Mock<I.ILog>();
            Mock<I.DB.IAddCategory> DbCategory = new Mock<I.DB.IAddCategory>();
            DbCategory.Setup(X => X.Action(It.IsAny<Category>())).Returns(category.LoadWithId(12));
            AddCategory addCategory = new AddCategory(DbCategory.Object, mockLog.Object);

            var result = addCategory.Action(category);

            mockLog.Verify(X => X.CatchError(It.IsAny<Exception>(), It.IsAny<object>()), Times.Never, "nie powinien wyskoczyæ b³¹d");
            DbCategory.Verify(X => X.Action(It.Is<Category>(Y => Y.Name == category.Name)));
            Assert.AreEqual(result.Name, category.Name);
            Assert.IsFalse(result.Id == 0);
        }

        [TestMethod]
        public void AddCategoryError()
        {
            Category category = new Category()
            {
                Name = "piwa"
            };
            Mock<I.ILog> mockLog = new Mock<I.ILog>();
            Mock<I.DB.IAddCategory> DbCategory = new Mock<I.DB.IAddCategory>();
            DbCategory.Setup(X => X.Action(It.IsAny<Category>())).Throws(new Exception());
            AddCategory addCategory = new AddCategory(DbCategory.Object, mockLog.Object);

            var result = addCategory.Action(category);

            mockLog.Verify(X => X.CatchError(It.IsAny<Exception>(), It.IsAny<object>()));
            DbCategory.Verify(X => X.Action(It.IsAny<Category>()));
            Assert.IsTrue(result == null);
            Assert.IsFalse(result.Id == 0);
        }
        [TestMethod]
        public void AddDocumentCorrect()
        {
            Document document = new Document()
            {
                Category = 11,
                Owner = 3,
                Name = "spis kwiatów w m&m 8"
            };
            Mock<I.DB.IAddDocument> db = new Mock<I.DB.IAddDocument>();
            Mock<I.ILog> log = new Mock<I.ILog>();
            db.Setup(X => X.Action(It.IsAny<Document>())).Returns(document.LoadCopyWithData());
            AddDocument addDocument = new AddDocument(db.Object, log.Object);

            var result = addDocument.Action(document);

            log.Verify(X => X.CatchError(It.IsAny<Exception>(), It.IsAny<object>()), Times.Never);
            db.Verify(X => X.Action(It.IsAny<Document>()));
            Assert.AreEqual(result.Category, document.Category);
            Assert.AreEqual(result.Owner, document.Owner);
            Assert.AreEqual(result.Name, document.Name);

        }

        [TestMethod]
        public void AddDocumentError()
        {
            Document document = new Document()
            {
                Category = 11,
                Owner = 3,
                Name = "spis kwiatów w m&m 8"
            };
            Mock<I.DB.IAddDocument> db = new Mock<I.DB.IAddDocument>();
            Mock<I.ILog> log = new Mock<I.ILog>();
            db.Setup(X => X.Action(It.IsAny<Document>())).Throws(new Exception());
            AddDocument addDocument = new AddDocument(db.Object, log.Object);

            var result = addDocument.Action(document);

            log.Verify(X => X.CatchError(It.IsAny<Exception>(), It.IsAny<object>()));
            db.Verify(X => X.Action(It.IsAny<Document>()));
            Assert.IsTrue(result == null);

        }
        [TestMethod]
        public void FindAutorCorrect()
        {
            List<Autor> autors = new List<Autor>()
            {
                new Autor(){FirstName="jarek", Id=3},
                new Autor(){FirstName="Jaœ", Id=4},

            };
            string prefix = "ja";
            Mock<I.DB.IFindAutor> db = new Mock<I.DB.IFindAutor>();
            Mock<I.ILog> log = new Mock<I.ILog>();
            db.Setup(X => X.Action("ja")).Returns(autors);
            FindAutor findAutor = new FindAutor(db.Object, log.Object);

            var result = findAutor.Action(prefix);

            Assert.IsTrue(result.SequenceEqual(autors));
            db.Verify(X => X.Action(prefix));
            log.Verify(X => X.CatchError(It.IsAny<Exception>(), It.IsAny<object>()), Times.Never);
        }

        [TestMethod]
        public void FindAutorError()
        {
            List<Autor> autors = new List<Autor>()
            {
                new Autor(){FirstName="jarek", Id=3},
                new Autor(){FirstName="Jaœ", Id=4},

            };
            string prefix = "ja";
            Mock<I.DB.IFindAutor> db = new Mock<I.DB.IFindAutor>();
            Mock<I.ILog> log = new Mock<I.ILog>();
            db.Setup(X => X.Action("ja")).Throws(new Exception());
            FindAutor findAutor = new FindAutor(db.Object, log.Object);

            var result = findAutor.Action(prefix);

            db.Verify(X => X.Action(prefix));
            log.Verify(X => X.CatchError(It.IsAny<Exception>(), It.IsAny<object>()));
        }

        [TestMethod]
        public void FindCategoryCorrect()
        {
            List<Category> Categorys = new List<Category>()
            {
                new Category(){Name="Jareka kwiaty", Id=3},
                new Category(){Name="Jaœa samochody", Id=4},

            };
            string prefix = "ja";
            Mock<I.DB.IFindCategory> db = new Mock<I.DB.IFindCategory>();
            Mock<I.ILog> log = new Mock<I.ILog>();
            db.Setup(X => X.Action("ja")).Returns(Categorys);
            FindCategory findCategory = new FindCategory(db.Object, log.Object);

            var result = findCategory.Action(prefix);

            Assert.IsTrue(result.SequenceEqual(Categorys));
            db.Verify(X => X.Action(prefix));
            log.Verify(X => X.CatchError(It.IsAny<Exception>(), It.IsAny<object>()), Times.Never);
        }

        [TestMethod]
        public void FindCategoryError()
        {
            List<Category> Categorys = new List<Category>()
            {
                new Category(){Name="Jareka kwiaty", Id=3},
                new Category(){Name="Jaœa samochody", Id=4},

            };
            string prefix = "ja";
            Mock<I.DB.IFindCategory> db = new Mock<I.DB.IFindCategory>();
            Mock<I.ILog> log = new Mock<I.ILog>();
            db.Setup(X => X.Action("ja")).Throws(new Exception());
            FindCategory findCategory = new FindCategory(db.Object, log.Object);

            var result = findCategory.Action(prefix);

            Assert.IsTrue(result == null);
            db.Verify(X => X.Action(prefix));
            log.Verify(X => X.CatchError(It.IsAny<Exception>(), It.IsAny<object>()));
        }
        [TestMethod]
        public void FindDocumentCorrect()
        {
            List<Document> Documents = new List<Document>()
            {
                new Document(){Name="Jareka kwiaty",Owner=11,Category=3},
                new Document(){Name="Jaœa samochody",Owner=11,Category=3},

            };
            var Filter = new DocumentFilter()
            {
                AutorId = 11,
                CategoryId = 3,
                Prefix = "ja"
            };
            Mock<I.DB.IFindDocument> db = new Mock<I.DB.IFindDocument>();
            Mock<I.ILog> log = new Mock<I.ILog>();
            db.Setup(X => X.Action(It.IsAny<DocumentFilter>())).Returns(Documents);
            FindDocument findDocument = new FindDocument(db.Object, log.Object);

            var result = findDocument.Action(It.IsAny<DocumentFilter>());

            Assert.IsTrue(result.SequenceEqual(Documents));
            db.Verify(X => X.Action(It.IsAny<DocumentFilter>()));
            log.Verify(X => X.CatchError(It.IsAny<Exception>(), It.IsAny<object>()), Times.Never);

        }

        [TestMethod]
        public void FindDocumentError()
        {
            List<Document> Documents = new List<Document>()
            {
                new Document(){Name="Jareka kwiaty",Owner=11,Category=3},
                new Document(){Name="Jaœa samochody",Owner=11,Category=3},

            };
            var Filter = new DocumentFilter()
            {
                AutorId = 11,
                CategoryId = 3,
                Prefix = "ja"
            };
            Mock<I.DB.IFindDocument> db = new Mock<I.DB.IFindDocument>();
            Mock<I.ILog> log = new Mock<I.ILog>();
            db.Setup(X => X.Action(It.IsAny<DocumentFilter>())).Throws(new Exception());
            FindDocument findDocument = new FindDocument(db.Object, log.Object);

            var result = findDocument.Action(It.IsAny<DocumentFilter>());

            Assert.IsTrue(result == null);
            db.Verify(X => X.Action(It.IsAny<DocumentFilter>()));
            log.Verify(X => X.CatchError(It.IsAny<Exception>(), It.IsAny<object>()));

        }
    }
}
