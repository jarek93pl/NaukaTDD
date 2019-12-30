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

    }
}
