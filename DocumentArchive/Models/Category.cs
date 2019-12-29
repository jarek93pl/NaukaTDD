using System;
using System.Collections.Generic;

namespace DocumentArchive.Models
{
    public partial class Category
    {
        public Category()
        {
            Document = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Document> Document { get; set; }
    }
}
