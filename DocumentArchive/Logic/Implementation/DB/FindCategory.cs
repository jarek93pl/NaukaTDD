using DocumentArchive.Logic.Interfaces.DB;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Logic.Implementation.DB
{
    public class FindCategory : IFindCategory
    {
        private readonly DocumentContext context;

        public FindCategory(DocumentContext context)
        {
            this.context = context;
        }
        public List<Category> Action(string prefix)
        {
            throw new NotImplementedException();
        }
    }
}
