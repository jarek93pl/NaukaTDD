using DocumentArchive.Filter;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Logic.Interfaces.DB
{
    public interface IFindDocument
    {
        List<Document> Action(DocumentFilter documentFilter);
    }
}
