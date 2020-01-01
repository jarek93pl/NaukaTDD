using DocumentArchive.Logic.Interfaces.Action;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inte = DocumentArchive.Logic.Interfaces;
namespace DocumentArchive.Logic.Implementation.Action
{
    public class FindDocument : IFindDocument
    {
        public inte.ILog log { get; set; }
        public inte.DB.IFindDocument connection { get; set; }
        public FindDocument(inte.DB.IFindDocument db, inte.ILog log)
        {
            connection = db;
            this.log = log;
        }
        public List<Document> Action(DocumentFilter documentFilter)
        {
            try
            {
                return connection.Action(documentFilter);
            }
            catch (Exception ex)
            {
                log.CatchError(ex, documentFilter);
                return null;
            }
        }
    }
}
