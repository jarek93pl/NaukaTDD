using DocumentArchive.Logic.Interfaces.DB;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Logic.Implementation.DB
{
    public class FindAutor : IFindAutor
    {
        private readonly DocumentContext context;

        public FindAutor(DocumentContext context)
        {
            this.context = context;
        }

        public List<Autor> Action(string prefix)
        {
            throw new NotImplementedException();
        }
    }
}
