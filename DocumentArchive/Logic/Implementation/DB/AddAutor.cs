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
        public DocumentContext Context { get; set; }
        public AddAutor(DocumentContext context)
        {
            this.Context = context;
        }
        Autor IAddAutor.Action(Autor autor)
        {
            using (Context)
            {
                Context.Add(autor);
                Context.SaveChanges();
                return autor;
            }
        }
    }
}
