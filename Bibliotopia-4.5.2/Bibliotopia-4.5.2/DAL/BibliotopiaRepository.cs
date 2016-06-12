using Bibliotopia_4._5._2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Security.Principal;

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
         
        public int GetFavoriteBookCountForNook(ReadingNook nook)
        {
            
            return nook.FavoriteBooks.ToList().Count();
        }

        public List<FavoriteBook> GetFavoriteBookCollectionForNook(ReadingNook nook)
        {
            return nook.FavoriteBooks.ToList();
        }

        public int GetToReadBookCountForNook(ReadingNook nook)
        {
            return nook.ToReadBooks.Count();
        }

        public List<ToReadBook> GetToReadBookCollectionForNook(ReadingNook nook)
        {
            return nook.ToReadBooks.ToList();
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

        public void AddBookToFavorites(Book fave_book, ReadingNook nook)
        {
            nook.FavoriteBooks.Add(new FavoriteBook { Book = fave_book, ReadingNook = nook });
            context.SaveChanges();
        }

        public void AddBookToReadBookList(Book to_read_book, ReadingNook reading_nook)
        {
            reading_nook.ToReadBooks.Add(new ToReadBook { Book = to_read_book, ReadingNook = reading_nook });
            context.SaveChanges();
        }
    }
}