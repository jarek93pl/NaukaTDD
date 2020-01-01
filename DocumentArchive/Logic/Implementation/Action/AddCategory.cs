using DocumentArchive.Logic.Interfaces.Action;
using DocumentArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inte = DocumentArchive.Logic.Interfaces;
namespace DocumentArchive.Logic.Implementation.Action
{
    public class AddCategory : IAddCategory
    {
        public inte.ILog log { get; set; }
        public inte.DB.IAddCategory connection { get; set; }
        public AddCategory(inte.DB.IAddCategory db, inte.ILog log)
        {
            connection = db;
            this.log = log;
        }
        public Category Action(Category category)
        {
            try
            {
                return connection.Action(category);
            }
            catch (Exception ex)
            {
                log.CatchError(ex, category);
                return null;
            }
        }
    }
}
