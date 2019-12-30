using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Logic.Interfaces.DB
{
    public interface IFindAutor
    {
        public List<Autor> Action(string prefix);
    }
}
