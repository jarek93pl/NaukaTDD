using DocumentArchive.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Filter
{
    public class DocumentFilter
    {

        public string CategoryIdtext
        {
            get
            {
                return CategoryId?.ToString() ?? "";
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    CategoryId = null;
                }
                else
                {
                    CategoryId = Convert.ToInt32(value);
                }
            }
        }
        public string AutorIdtext
        {
            get
            {
                return AutorId?.ToString() ?? "";
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    AutorId = null;
                }
                else
                {
                    AutorId = Convert.ToInt32(value);
                }
            }
        }
        public int? CategoryId { get; set; }
        public int? AutorId { get; set; }
        public DateTime BeginCreateDate { get; set; }
        public DateTime EndCreateDate { get; set; }

        public string BeginCreateDateString
        {
            get
            {
                return BeginCreateDate.ToString();
            }
            set
            {
                BeginCreateDate = DateTime.Parse(value);
            }
        }
        public string EndCreateDateString
        {
            get
            {
                return EndCreateDate.ToString();
            }
            set
            {
                EndCreateDate = DateTime.Parse(value);
            }
        }
        public string Prefix { get; set; }
        public IEnumerable<Document> Use(DbSet<Document> document)
        {
            return document.
                Include(x => x.CategoryNavigation).Include(x => x.OwnerNavigation).Where(
                x =>
               ((x.Category == CategoryId) || CategoryId == null) &&
                x.DateCreated < EndCreateDate && BeginCreateDate < x.DateCreated &&
                 (Prefix == null || EF.Functions.Like(x.Name, $"{Prefix}%")) &&
                (AutorId == null || x.Owner == AutorId));


        }
    }
}
