using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotopia_4._5._2.Models
{
    public class BookToRead
    {
        public virtual ApplicationUser Id { get; set; }
        public virtual Book Book { get; set; }
        public virtual ReadingNook ReadingNook { get; set; }
    }
}