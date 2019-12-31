using DocumentArchive.Logic.Interfaces.DB;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Logic.Implementation.DB
{
    public class AddAutor : IAddAutor
    {
        public DocumentContext context { get; set; }
        public AddAutor(DocumentContext context)
        {
            this.context = context;
        }
        Autor IAddAutor.Action(Autor autor)
        {
            throw new NotImplementedException();
        }
    }
}
