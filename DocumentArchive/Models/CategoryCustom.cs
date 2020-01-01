using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentArchive.Models
{
    public partial class Category
    {

        public Category LoadWithId(int id)
        {
            Category category = (Category)MemberwiseClone();
            category.Id = id;
            return category;
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
