using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DocumentArchive.Logic.Implementation.Action;
using DocumentArchive.Logic.Interfaces.Action;
using DocumentArchive.Models;
//using DocumentArchive.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using DocumentArchive.Models;

namespace DocumentArchive.Controllers
{
    public class HomeController : Controller
    {
        //FindAutor
        readonly Logic.Interfaces.Action.IAddAutor addAutor;
        readonly Logic.Interfaces.Action.IFindAutor findAutor;

        readonly Logic.Interfaces.Action.IFindCategory findCategory;
        readonly Logic.Interfaces.Action.IAddCategory addCategory;

        readonly Logic.Interfaces.Action.IAddDocument addDocument;
        readonly Logic.Interfaces.Action.IFindDocument findDocument;
        public HomeController
            (Logic.Interfaces.Action.IAddAutor addAutor, 
            Logic.Interfaces.Action.IFindAutor findAutor,
            Logic.Interfaces.Action.IFindCategory findCategory,
            Logic.Interfaces.Action.IAddCategory addCategory,
            Logic.Interfaces.Action.IAddDocument addDocument,
            Logic.Interfaces.Action.IFindDocument findDocument)
        {
            this.addAutor = addAutor;
            this.findAutor = findAutor;

            this.findCategory = findCategory;
            this.addCategory = addCategory;

            this.addDocument = addDocument;
            this.findDocument = findDocument;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAutor([FromBody]  Autor autor)
        {
            return Json(addAutor.Action(autor));
        }
        [HttpPost]
        public ActionResult FindAutor([FromBody]  string prefix)
        {
            return Json(findAutor.Action(prefix));
        }


        [HttpPost]
        public ActionResult AddCategory([FromBody]  Category category)
        {
            return Json(addCategory.Action(category));
        }
        [HttpPost]
        public ActionResult FindCategory([FromBody]  string prefix)
        {
            return Json(findCategory.Action(prefix));
        }

        [HttpPost]
        public ActionResult AddDocument([FromBody]  Document document)
        {
            return Json(addDocument.Action(document));
        }
        [HttpPost]
        public ActionResult FindDocument([FromBody]  DocumentFilter filter)
        {
            return Json(findDocument.Action(filter));
        }
    }
}
