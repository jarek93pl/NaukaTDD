using DocumentArchive.Logic.Interfaces.Action;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inte = DocumentArchive.Logic.Interfaces;
namespace DocumentArchive.Logic.Implementation.Action
{
    public class FindAutor : IFindAutor
    {
        public inte.ILog log { get; set; }
        public inte.DB.IFindAutor connection { get; set; }
        public FindAutor(inte.DB.IFindAutor db, inte.ILog log)
        {
            connection = db;
            this.log = log;
        }
        public List<Autor> Action(string prefix)
        {
            try
            {
                return connection.Action(prefix);
            }
            catch (Exception ex)
            {
                log.CatchError(ex, prefix);
                return null;
            }
        }
    }
}
