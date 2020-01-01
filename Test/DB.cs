using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DocumentArchive.Logic.Implementation.DB;
using DocumentArchive.Logic.Interfaces.DB;
using Moq;
using DocumentArchive.Models;
using Moq.EntityFrameworkCore;
using System.Linq;
namespace Test
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class DB
    {
        [TestMethod]
        public void AddAutorFilter()
        {
            Autor autor = new Autor()
            {
                LastName = "Gosławski",
                FirstName = "Jarosław"


            };
            Mock<DocumentContext> mock = new Mock<DocumentContext>();
            mock.Setup(x => x.Autor).ReturnsDbSet((IList<Autor>)new Autor[] { });
            IAddAutor addAutor = new AddAutor(mock.Object);

            var result = addAutor.Action(autor);

            Assert.IsTrue(mock.Object.Autor.Any(X => X.FirstName == autor.FirstName && X.LastName == autor.LastName));
            mock.Verify(X => X.SaveChanges());

        }

        [TestMethod]
        public void AddCategoryFilter()
        {
            Category Category = new Category()
            {
                Name = "lebnitz"


            };
            Mock<DocumentContext> mock = new Mock<DocumentContext>();
            mock.Setup(x => x.Category).ReturnsDbSet((IList<Category>)new Category[] { });
            IAddCategory addCategory = new AddCategory(mock.Object);

            var result = addCategory.Action(Category);

            Assert.IsTrue(mock.Object.Category.Any(X => X.Name == Category.Name));
            mock.Verify(X => X.SaveChanges());

        }


        [TestMethod]
        public void AddDocumentFilter()
        {
            Document Document = new Document()
            {
                Name = "lebnitz",
                Owner = 11,
                Category = 3

            };
            Mock<DocumentContext> mock = new Mock<DocumentContext>();
            mock.Setup(x => x.Document).ReturnsDbSet((IList<Document>)new Document[] { });
            IAddDocument addDocument = new AddDocument(mock.Object);

            var result = addDocument.Action(Document);

            Assert.IsTrue(mock.Object.Document.Any(X => X.Name == Document.Name));
            mock.Verify(X => X.SaveChanges());
        }
        [TestMethod]
        public void FindAutorFilter()
        {
            List<Autor> autors = new List<Autor>()
            {
                new Autor(){FirstName ="przemek"},
                new Autor(){FirstName ="kamil"},
                new Autor(){FirstName ="jarek"},
            };
            Mock<DocumentContext> mock = new Mock<DocumentContext>();
            mock.Setup(x => x.Autor).ReturnsDbSet(autors);
            FindAutor findAutor = new FindAutor(mock.Object);

            var result = findAutor.Action("ja");

            Assert.IsTrue(result.First().FirstName == "jarek");

        }

        [TestMethod]
        public void FindAutorNonFilter()
        {
            List<Autor> autors = new List<Autor>()
            {
                new Autor(){FirstName ="przemek"},
                new Autor(){FirstName ="kamil"},
                new Autor(){FirstName ="jarek"},
            };
            Mock<DocumentContext> mock = new Mock<DocumentContext>();
            mock.Setup(x => x.Autor).ReturnsDbSet(autors);
            FindAutor findAutor = new FindAutor(mock.Object);

            var result = findAutor.Action(null);

            Assert.IsTrue(result.Count == 3);

        }
        [TestMethod]
        public void FindCategoryFilter()
        {
            List<Category> Categorys = new List<Category>()
            {
                new Category(){Name ="przemek"},
                new Category(){Name ="kamil"},
                new Category(){Name ="jarek"},
            };
            Mock<DocumentContext> mock = new Mock<DocumentContext>();
            mock.Setup(x => x.Category).ReturnsDbSet(Categorys);
            FindCategory findCategory = new FindCategory(mock.Object);

            var result = findCategory.Action("ja");

            Assert.IsTrue(result.First().Name == "jarek");

        }

        [TestMethod]
        public void FindCategoryNonFilter()
        {
            List<Category> Categorys = new List<Category>()
            {
                new Category(){Name ="przemek"},
                new Category(){Name ="kamil"},
                new Category(){Name ="jarek"},
            };
            Mock<DocumentContext> mock = new Mock<DocumentContext>();
            mock.Setup(x => x.Category).ReturnsDbSet(Categorys);
            FindCategory findCategory = new FindCategory(mock.Object);

            var result = findCategory.Action(null);

            Assert.IsTrue(result.Count == 3);

        }

        [TestMethod]
        public void FindDocumentFilter()
        {
            DocumentFilter documentFilter = new DocumentFilter()
            {
                AutorId = 1,
                CategoryId = 2,
                BeginCreateDate = new DateTime(2013, 1, 1),
                EndCreateDate = new DateTime(2020, 1, 1),
                Prefix = "j"

            };
            var correct1 = new Document() { Category = 2, Owner = 1, DateCreated = new DateTime(2015, 3, 1), Name = "j1" };
            var correct2 = new Document() { Category = 2, Owner = 1, DateCreated = new DateTime(2017, 3, 1), Name = "j2" };
            List<Document> Documents = new List<Document>()
            {
                correct1,
                correct2,
                new Document(){Category=2,Owner=2,DateCreated= new DateTime(2015,3,1), Name ="a1"},
                new Document(){Category=2,Owner=1,DateCreated= new DateTime(2017,3,1), Name ="a2"},
                new Document(){Category=2,Owner=1,DateCreated= new DateTime(2000,3,1), Name ="j1"},
                new Document(){Category=3,Owner=1,DateCreated= new DateTime(2000,3,1), Name ="j2"},
                new Document(){Category=2,Owner=5,DateCreated= new DateTime(2015,3,1), Name ="j1"},
                new Document(){Category=5,Owner=5,DateCreated= new DateTime(2017,3,1), Name ="j2"},
            };
            Mock<DocumentContext> mock = new Mock<DocumentContext>();
            mock.Setup(x => x.Document).ReturnsDbSet(Documents);
            FindDocument findDocument = new FindDocument(mock.Object);

            var result = findDocument.Action(documentFilter);

            Assert.IsTrue(result[0].DateCreated == correct1.DateCreated && result[0].Name == correct1.Name);
            Assert.IsTrue(result[1].DateCreated == correct2.DateCreated && result[1].Name == correct2.Name);

        }

        [TestMethod]
        public void FindDocumentNonFilter()
        {
            List<Document> Documents = new List<Document>()
            {
                new Document(){Name ="przemek"},
                new Document(){Name ="kamil"},
                new Document(){Name ="jarek"},
            };
            Mock<DocumentContext> mock = new Mock<DocumentContext>();
            mock.Setup(x => x.Document).ReturnsDbSet(Documents);
            FindDocument findDocument = new FindDocument(mock.Object);

            var result = findDocument.Action(null);

            Assert.IsTrue(result.Count == 3);

        }
    }
}
