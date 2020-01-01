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
        public DocumentContext Context { get; set; }
        public AddCategory(DocumentContext context)
        {
            this.Context = context;
        }
        Category IAddCategory.Action(Category category)
        {
            using (Context)
            {
                Context.Category.Add(category);
                Context.SaveChanges();
                return category;
            }
        }
    }
}
