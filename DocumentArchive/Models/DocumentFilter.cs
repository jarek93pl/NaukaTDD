using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Models
{
    public class DocumentFilter
    {
        public int? CategoryId { get; set; }
        public int? AutorId { get; set; }
        public DateTime BeginCreateDate { get; set; }
        public DateTime EndCreateDate { get; set; }
        public string Prefix { get; set; }
        public IEnumerable<Document> Use(IEnumerable<Document> document)
        {
            return document.Where(
                x =>
                (x.Category == null || x.Category == CategoryId) &&
                x.DateCreated < EndCreateDate && BeginCreateDate < x.DateCreated &&
                 (Prefix == null || EF.Functions.Like(x.Name, $"{Prefix}%")) &&
                (x.Owner == null || x.Owner == AutorId));


        }
    }
}
