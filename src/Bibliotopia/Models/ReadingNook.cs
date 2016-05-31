using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotopia.Models
{
    public class ReadingNook
    {
        public List<Book> ReadBooks { get; set; }
        public List<Book> BooksToRead { get; set; }
    }
}
