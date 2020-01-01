using DocumentArchive.Logic.Interfaces.Action;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inte = DocumentArchive.Logic.Interfaces;
namespace DocumentArchive.Logic.Implementation.Action
{
    public class AddDocument : IAddDocument
    {
        public inte.ILog log { get; set; }
        public inte.DB.IAddDocument connection { get; set; }
        public AddDocument(inte.DB.IAddDocument db, inte.ILog log)
        {
            connection = db;
            this.log = log;
        }
        public Document Action(Document Document)
        {
            try
            {
                return connection.Action(Document);
            }
            catch (Exception ex)
            {
                log.CatchError(ex, Document);
                return null;
            }
        }
    }
}
