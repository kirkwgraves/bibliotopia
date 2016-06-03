using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotopia_4._5._2.Models
{
    public class ReadingNook
    {
        public virtual ApplicationUser Id { get; set; }
        public virtual FavoriteBook FavoriteBook { get
            {
                throw new NotImplementedException();
            }
        }
        public virtual BookToRead BookToRead { get
            {
                throw new NotImplementedException();
                // Write LINQ expression to retrieve collection
            }
        }

        // Reseach composite key vs. surrogate key
    }
}