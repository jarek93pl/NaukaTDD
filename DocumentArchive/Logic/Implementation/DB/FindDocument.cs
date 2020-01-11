using DocumentArchive.Filter;
using DocumentArchive.Logic.Interfaces.DB;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Logic.Implementation.DB
{
    public class FindDocument : IFindDocument
    {
        private readonly DocumentContext context;
        public FindDocument(DocumentContext context)
        {
            this.context = context;
        }
        public List<Document> Action(DocumentFilter documentFilter)
        {
            using (context)
            {
                if (documentFilter == null)
                {
                    return context.Document.ToList();
                }
                else
                {
                   return documentFilter.Use(context.Document).ToList();
                }
            }
        }
    }
}
