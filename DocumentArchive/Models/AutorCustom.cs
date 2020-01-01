using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Models
{
    public partial class Autor
    {
        public Autor LoadWithId(int id)
        {
            Autor autor = (Autor)MemberwiseClone();
            autor.Id = id;
            return autor;
        }
        public override bool Equals(object obj)
        {
            if (obj is Autor a)
            {
                return a.Id == Id;
            }
            else
            {
                return false;
            }
        }
    }
}
