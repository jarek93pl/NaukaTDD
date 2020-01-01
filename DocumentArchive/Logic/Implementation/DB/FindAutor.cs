using DocumentArchive.Logic.Interfaces.DB;
using DocumentArchive.Models;
using Microsoft.EntityFrameworkCore;
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
            using (context)
            {
                if (prefix == null)
                {
                    return context.Autor.ToList();
                }
                else
                {
                    return context.Autor.Where(x => EF.Functions.Like(x.FirstName, $"{prefix}%")).ToList();
                }
            }
        }
    }
}
