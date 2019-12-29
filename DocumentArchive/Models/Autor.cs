using System;
using System.Collections.Generic;

namespace DocumentArchive.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Document = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Document> Document { get; set; }
    }
}
