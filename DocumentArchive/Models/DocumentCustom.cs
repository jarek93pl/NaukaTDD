using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Models
{
    public partial class Document
    {
        public Document LoadCopyWithData()
        {
            Document document = (Document)MemberwiseClone();
            document.DateCreated = DateTime.Now;
            return document;
        }
        public override bool Equals(object obj)
        {
            if (obj is Document d)
            {
                return d.Name == Name && d.DateCreated == DateCreated;
            }
            else
            {
                return false;
            }
        }
    }
}
