using Bibliotopia_4._5._2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bibliotopia_4._5._2.DAL
{
    public class BibliotopiaRepository
    {
        private BibliotopiaContext context;
        public IDbSet<ApplicationUser> Users
        {
            get { return context.Users; }
        }

        public BibliotopiaRepository()
        {
            context = new BibliotopiaContext();
        }

        // This will allow me to isolate the Repo from Context during testing
        public BibliotopiaRepository(BibliotopiaContext _context)
        {
            context = _context;
        }

        public ApplicationUser GetUser(string user_id)
        {
            return context.Users.FirstOrDefault(i => i.Id == user_id);
        }
          // Check out AspNet.Identity namespace 
            // GetUser Id
            // GetUserById


        public int GetFavoriteBookCountForUser(ApplicationUser user)
        {
            IQueryable<FavoriteBook> favorites_query =
                from faves in context.FavoriteBooks
                where faves.Owner.Id == user.Id
                select faves;
            return favorites_query.ToList().Count();
        }

        public int GetBookToReadCountForUser(ApplicationUser user)
        {
            IQueryable<BookToRead> books_to_read_query =
                from books in context.BooksToRead
                where books.Owner.Id == user.Id
                select books;
            return books_to_read_query.ToList().Count();
        }
    }
}