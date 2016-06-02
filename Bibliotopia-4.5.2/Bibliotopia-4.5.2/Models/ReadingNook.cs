using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotopia_4._5._2.Models
{
    public class ReadingNook
    {
        public int ReadingNookId { get; set; }
        public FavoriteBook FavoriteBook { get; set; }
        public BookToRead BookToRead { get; set; }

    }
}