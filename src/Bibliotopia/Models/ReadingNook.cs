using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotopia.Models
{
    public class ReadingNook
    {
        public int ReadingNookId { get; set; }
        public List<Book> FavoriteBooks { get; set; }
        public List<Book> BooksToRead { get; set; }
        public ApplicationUser UserId { get; set; }
    }
}
