using DocumentArchive.Logic.Interfaces.DB;
using DocumentArchive.Models;
using Microsoft.EntityFrameworkCore;
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
            using (context)
            {
                if (prefix == null)
                {
                    return context.Category.ToList();
                }
                else
                {
                    return context.Category.Where(x => EF.Functions.Like(x.Name, $"{prefix}%")).ToList();
                }
            }
        }
    }
}
