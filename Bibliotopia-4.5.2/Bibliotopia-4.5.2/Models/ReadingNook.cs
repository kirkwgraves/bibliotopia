using Bibliotopia_4._5._2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotopia_4._5._2.Models
{
    public class ReadingNook
    {
        public virtual int ReadingNookId { get; set; }
        public virtual ApplicationUser Id { get; set; }
        public virtual IQueryable<FavoriteBook> FavoriteBook { get
            {
                var context = new BibliotopiaContext();
                IQueryable<FavoriteBook> favorites_query =
                    from faves in context.FavoriteBooks
                    where faves.Id == faves.ReadingNook.Id
                    select faves;
                return favorites_query;
            }
        }
        public virtual IQueryable<BookToRead> BookToRead { get
            {
                var context = new BibliotopiaContext();
                IQueryable<BookToRead> books_to_read_query =
                    from books in context.BooksToRead
                    where books.Id == books.ReadingNook.Id
                    select books;
                return books_to_read_query;
            }
        }

        // Reseach composite key vs. surrogate key
    }
}