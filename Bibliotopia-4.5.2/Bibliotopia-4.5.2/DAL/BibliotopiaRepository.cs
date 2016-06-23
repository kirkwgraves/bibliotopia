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

        public int GetFavoriteBookCountForNook(string user_id)
        {
            var nooks = context.ReadingNooks;
            var selected_nook = nooks.FirstOrDefault(n => n.Owner.Id == user_id);
            return selected_nook.FavoriteBooks.Count;
        }
        
        public ReadingNook GetNookForGivenUser(string user_id)
        {
            var nooks = context.ReadingNooks;
            var selected_nook = nooks.FirstOrDefault(n => n.Owner.Id == user_id);
            return selected_nook;
        }

        public List<Book> GetFavoriteBookCollectionForNook(string user_id)
        {
            var user_nook = GetNookForGivenUser(user_id);
            var faves = context.FavoriteBooks.Where(f => f.ReadingNook.Owner.Id == user_id);

            IQueryable<Book> fave_books_query =
                from f in faves
                select f.Book;

            return fave_books_query.ToList();
           
        }

        public int GetToReadBookCountForNook(string user_id)
        {
            var nooks = context.ReadingNooks;
            var selected_nook = nooks.FirstOrDefault(n => n.Owner.Id == user_id);
            return selected_nook.ToReadBooks.Count();
        }

        public List<ToReadBook> GetToReadBookCollectionForNook(string user_id)
        {
            var nooks = context.ReadingNooks;
            var selected_nook = nooks.FirstOrDefault(n => n.Owner.Id == user_id);
            return selected_nook.ToReadBooks.ToList();
        }

        public List<ReadingNook> GetAllReadingNooks()
        {
            return context.ReadingNooks.ToList();
        }

        public ReadingNook CreateReadingNook(string user_id)
        {
            var nooks = context.ReadingNooks;
            var owner = GetUser(user_id);
            if (nooks.FirstOrDefault(n => n.Owner.Id == user_id) != null)
            {
                throw new Exception("Reading Nook already exists for this user!");
            }

            ReadingNook new_nook = new ReadingNook
            {
                Owner = owner
            };

            context.ReadingNooks.Add(new_nook);
            context.SaveChanges();
            return new_nook;
        }

        public int GetReadingNookCount()
        {
            return context.ReadingNooks.Count();
        }

        public void AddBookToFavorites(string user_id, Book fave_book)
        {
            var nook = GetNookForGivenUser(user_id);
            nook.FavoriteBooks.Add(new FavoriteBook { Book = fave_book, ReadingNook = nook });
            context.SaveChanges();
        }

        public void AddBookToReadBookList(string user_id, Book to_read_book)
        {
            var nook = GetNookForGivenUser(user_id);
            nook.ToReadBooks.Add(new ToReadBook { Book = to_read_book, ReadingNook = nook });
            context.SaveChanges();
        }
    }
}