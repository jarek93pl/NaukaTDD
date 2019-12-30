﻿using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Logic.Interfaces.Action
{
    public interface IFindDocument
    {
        List<Document> Action(DocumentFilter documentFilter);
    }
}
