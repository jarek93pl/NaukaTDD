using System;
using System.Collections.Generic;

namespace DocumentArchive.Models
{
    public partial class Document
    {
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public int? Owner { get; set; }
        public int? Category { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual Autor OwnerNavigation { get; set; }
    }
}
