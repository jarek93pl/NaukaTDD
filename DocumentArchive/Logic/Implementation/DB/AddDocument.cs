using DocumentArchive.Logic.Interfaces.DB;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Logic.Implementation.DB
{
    public class AddDocument : IAddDocument
    {
        private readonly DocumentContext context;

        public AddDocument(DocumentContext context)
        {
            this.context = context;
        }

        public Document Action(Document document)
        {
            using (context)
            {
                context.Document.Add(document);
                context.SaveChanges();
                return document;
            }
        }
    }
}
