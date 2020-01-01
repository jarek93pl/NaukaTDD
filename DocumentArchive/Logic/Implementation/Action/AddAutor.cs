using DocumentArchive.Logic.Interfaces.Action;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inte = DocumentArchive.Logic.Interfaces;
namespace DocumentArchive.Logic.Implementation.Action
{
    public class AddAutor : IAddAutor
    {
        public inte.ILog log { get; set; }
        public inte.DB.IAddAutor connection { get; set; }
        public AddAutor(inte.DB.IAddAutor db, inte.ILog log)
        {
            connection = db;
            this.log = log;
        }
        Autor IAddAutor.Action(Autor autor)
        {
            try
            {
                return connection.Action(autor);
            }
            catch (Exception ex)
            {
                log.CatchError(ex, autor);
                return null;
            }
        }
    }
}
