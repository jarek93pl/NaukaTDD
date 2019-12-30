using DocumentArchive.Logic.Interfaces.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Logic.Implementation.Action
{
    public class AddAutor : Interfaces.Action.IAddAutor
    {
        private readonly Interfaces.DB.IAddAutor connection;

        public AddAutor(DocumentArchive.Logic.Interfaces.DB.IAddAutor connection)
        {
            this.connection = connection;
        }
    }
}
