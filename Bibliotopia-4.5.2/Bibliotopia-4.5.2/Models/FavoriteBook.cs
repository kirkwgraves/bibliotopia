using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotopia_4._5._2.Models
{
    public class FavoriteBook
    {
        public virtual int FavoriteBookId { get; set; }
        public virtual Book Book { get; set; }
        public virtual ReadingNook ReadingNook { get; set; }
    }
}