using DocumentArchive.Logic.Interfaces.Action;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inte = DocumentArchive.Logic.Interfaces;
namespace DocumentArchive.Logic.Implementation.Action
{
    public class FindCategory : IFindCategory
    {
        public inte.ILog log { get; set; }
        public inte.DB.IFindCategory connection { get; set; }
        public FindCategory(inte.DB.IFindCategory db, inte.ILog log)
        {
            connection = db;
            this.log = log;
        }
        public List<Category> Action(string prefix)
        {
            throw new NotImplementedException();
        }
    }
}