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
        public BibliotopiaContext context;
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


        public int GetFavoriteBookCountForNook(ReadingNook nook)
        {
            IQueryable<FavoriteBook> favorites_query =
                from faves in context.FavoriteBooks
                where faves.ReadingNookId == nook.ReadingNookId
                select faves;
            return favorites_query.ToList().Count();
        }

        public List<FavoriteBook> GetFavoriteBookCollectionForNook(ReadingNook nook)
        {
            IQueryable<FavoriteBook> favorites_query =
                from faves in context.FavoriteBooks
                where faves.ReadingNookId == nook.ReadingNookId
                select faves;
            return favorites_query.ToList();
        }

        public int GetBookToReadCountForNook(ReadingNook nook)
        {
            IQueryable<ToReadBook> books_to_read_query =
                from books in context.ToReadBooks
                where books.ReadingNookId == nook.ReadingNookId
                select books;
            return books_to_read_query.ToList().Count();
        }

        public List<ToReadBook> GetBookToReadCollectionForNook(ReadingNook nook)
        {
            IQueryable<ToReadBook> books_to_read_query =
                from books in context.ToReadBooks
                where books.ReadingNookId == nook.ReadingNookId
                select books;
            return books_to_read_query.ToList();
        }

        public List<ReadingNook> GetReadingNooks()
        {
            return context.ReadingNooks.ToList();
        }

        public void AddReadingNook(ReadingNook new_nook)
        {
            context.ReadingNooks.Add(new_nook);
            context.SaveChanges();
        }

        public int GetReadingNookCount()
        {
            return context.ReadingNooks.Count();
        }
    }
}