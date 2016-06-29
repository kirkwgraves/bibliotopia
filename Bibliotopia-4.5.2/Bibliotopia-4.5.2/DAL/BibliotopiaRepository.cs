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

        public List<Book> GetToReadBookCollectionForNook(string user_id)
        {
            var user_nook = GetNookForGivenUser(user_id);
            var to_read_books = context.ToReadBooks.Where(t => t.ReadingNook.Owner.Id == user_id);

            IQueryable<Book> to_read_books_query =
                from t in to_read_books
                select t.Book;

            return to_read_books_query.ToList();
        }

        public Book GetToReadBook(string user_id, Book book)
        {
            List<Book> to_reads = GetToReadBookCollectionForNook(user_id);
            var selected_book = to_reads.Where(t => t.BookId == book.BookId);
            return selected_book.ToList().First();
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

        public void RemoveBookFromFavorites(string user_id, Book book_to_remove)
        {
            var nook = GetNookForGivenUser(user_id);
            FavoriteBook fave_to_remove = context.FavoriteBooks.First(f => f.Book.BookId == book_to_remove.BookId);
            FavoriteBook favorite_book = context.FavoriteBooks.Find(fave_to_remove.FavoriteBookId);
            nook.FavoriteBooks.Remove(favorite_book);
            context.SaveChanges();
        }

        public void AddBookToReadBookList(string user_id, Book to_read_book)
        {
            var nook = GetNookForGivenUser(user_id);
            nook.ToReadBooks.Add(new ToReadBook { Book = to_read_book, ReadingNook = nook });
            context.SaveChanges();
        }

        public void RemoveBookFromToReadBookList(string user_id, Book to_read_book)
        {
            var nook = GetNookForGivenUser(user_id);
            ToReadBook book_to_remove = context.ToReadBooks.First(t => t.Book.BookId == to_read_book.BookId);
            nook.ToReadBooks.Remove(book_to_remove);
            context.SaveChanges();
        }
    }
}