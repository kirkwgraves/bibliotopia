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
        List<ReadingNook> readingNook_datasource { get; set; }
        Mock<DbSet<ReadingNook>> mock_readingNooks_table { get; set; }
        IQueryable<ReadingNook> readingNook_data { get; set; }

        // FavoriteBooks
        List<FavoriteBook> favoriteBook_datasource { get; set; }
        Mock<DbSet<FavoriteBook>> mock_favoriteBooks_table { get; set; }
        IQueryable<FavoriteBook> favoriteBook_data { get; set; }

        // BooksToRead
        List<BookToRead> booksToRead_datasource { get; set; }
        Mock<DbSet<BookToRead>> mock_booksToRead_table { get; set; }
        IQueryable<BookToRead> bookToRead_data { get; set; }

        // 


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
