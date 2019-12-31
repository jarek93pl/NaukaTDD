using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentArchive.Logic.Interfaces.DB;
using DocumentArchive.Models;

namespace DocumentArchive.Logic.Implementation.DB
{
    public class AddCategory : IAddCategory
    {
        public DocumentContext context { get; set; }
        public AddCategory(DocumentContext context)
        {
            this.context = context;
        }
        Category IAddCategory.Action(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
