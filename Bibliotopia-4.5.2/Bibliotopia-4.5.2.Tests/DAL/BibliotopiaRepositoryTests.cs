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
            // Tells fake DbSet to use datasource as something queryable
            mock_readingNooks_table.As<IQueryable<ReadingNook>>().Setup(m => m.GetEnumerator()).Returns(readingNook_data.GetEnumerator());
            mock_readingNooks_table.As<IQueryable<ReadingNook>>().Setup(m => m.ElementType).Returns(readingNook_data.ElementType);
            mock_readingNooks_table.As<IQueryable<ReadingNook>>().Setup(m => m.Expression).Returns(readingNook_data.Expression);
            mock_readingNooks_table.As<IQueryable<ReadingNook>>().Setup(m => m.Provider).Returns(readingNook_data.Provider);

            // Tells mocked BibliotopiaContext to use fully mocked datasource (List<ReadingNook>)
            mock_context.Setup(m => m.ReadingNooks).Returns(mock_readingNooks_table.Object);

            // Tells fake DbSet to use datasource as something queryable
            mock_favoriteBooks_table.As<IQueryable<FavoriteBook>>().Setup(m => m.GetEnumerator()).Returns(favoriteBook_data.GetEnumerator());
            mock_favoriteBooks_table.As<IQueryable<FavoriteBook>>().Setup(m => m.ElementType).Returns(favoriteBook_data.ElementType);
            mock_favoriteBooks_table.As<IQueryable<FavoriteBook>>().Setup(m => m.Expression).Returns(favoriteBook_data.Expression);
            mock_favoriteBooks_table.As<IQueryable<FavoriteBook>>().Setup(m => m.Provider).Returns(favoriteBook_data.Provider);

            // Tells mocked BibliotopiaContext to use fully mocked datasource (List<FavoriteBook>)
            mock_context.Setup(m => m.FavoriteBooks).Returns(mock_favoriteBooks_table.Object);

            // Tells fake DbSet to use datasource as something queryable
            mock_booksToRead_table.As<IQueryable<BookToRead>>().Setup(m => m.GetEnumerator()).Returns(bookToRead_data.GetEnumerator());
            mock_booksToRead_table.As<IQueryable<BookToRead>>().Setup(m => m.ElementType).Returns(bookToRead_data.ElementType);
            mock_booksToRead_table.As<IQueryable<BookToRead>>().Setup(m => m.Expression).Returns(bookToRead_data.Expression);
            mock_booksToRead_table.As<IQueryable<BookToRead>>().Setup(m => m.Provider).Returns(bookToRead_data.Provider);

            // Tells mocked BibliotopiaContext to use fully mocked datasource (List<BookToRead>)
            mock_context.Setup(m => m.BooksToRead).Returns(mock_booksToRead_table.Object);

            // Tells fake DbSet to use datasource as something queryable
            mock_books_table.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(book_data.GetEnumerator());
            mock_books_table.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(book_data.ElementType);
            mock_books_table.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(book_data.Expression);
            mock_books_table.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(book_data.Provider);

            // Tells mocked BibliotopiaContext to use fully mocked datasource (List<Book>)
            mock_context.Setup(m => m.Books).Returns(mock_books_table.Object); 
        }
    }
}
