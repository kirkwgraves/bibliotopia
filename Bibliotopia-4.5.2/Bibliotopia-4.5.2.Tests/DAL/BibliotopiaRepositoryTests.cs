using System;
using System.Data.Entity;
using Moq;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bibliotopia_4._5._2.DAL;
using Bibliotopia_4._5._2.Models;
using System.Collections.Generic;

namespace Bibliotopia_4._5._2.Tests.DAL
{
    [TestClass]
    public class BibliotopiaRepositoryTests
    {
        Mock<BibliotopiaContext> mock_context { get; set; }

        // Injects mocked BibliotopiaContext
        BibliotopiaRepository repo { get; set; }

        // ReadingNooks
        List<ReadingNook> readingNooks_datasource { get; set; }
        Mock<DbSet<ReadingNook>> mock_readingNooks_table { get; set; }
        IQueryable<ReadingNook> readingNook_data { get; set; }

        // FavoriteBooks
        List<FavoriteBook> favoriteBooks_datasource { get; set; }
        Mock<DbSet<FavoriteBook>> mock_favoriteBooks_table { get; set; }
        IQueryable<FavoriteBook> favoriteBook_data { get; set; }

        // BooksToRead
        List<BookToRead> booksToRead_datasource { get; set; }
        Mock<DbSet<BookToRead>> mock_booksToRead_table { get; set; }
        IQueryable<BookToRead> bookToRead_data { get; set; }

        // Books
        List<Book> books_datasource { get; set; }
        Mock<DbSet<Book>> mock_books_table { get; set; }
        IQueryable<Book> book_data { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<BibliotopiaContext>();

            readingNooks_datasource = new List<ReadingNook>();
            favoriteBooks_datasource = new List<FavoriteBook>();
            booksToRead_datasource = new List<BookToRead>();
            books_datasource = new List<Book>();

            mock_readingNooks_table = new Mock<DbSet<ReadingNook>>();
            mock_favoriteBooks_table = new Mock<DbSet<FavoriteBook>>();
            mock_booksToRead_table = new Mock<DbSet<BookToRead>>();
            mock_books_table = new Mock<DbSet<Book>>();

            repo = new BibliotopiaRepository(mock_context.Object);

            readingNook_data = readingNooks_datasource.AsQueryable();
            favoriteBook_data = favoriteBooks_datasource.AsQueryable();
            bookToRead_data = booksToRead_datasource.AsQueryable();
            book_data = books_datasource.AsQueryable();
        }

        [TestCleanup]
        public void Cleanup()
        {
            readingNooks_datasource = null;
            favoriteBooks_datasource = null;
            booksToRead_datasource = null;
            books_datasource = null;
        }

        [TestMethod]
        void ConnectMocksToDatastore() // Utility method
        {

        }
    }
}
