using Bibliotopia_4._5._2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bibliotopia_4._5._2.DAL
{
    public class BibliotopiaContext : ApplicationDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<ReadingNook> ReadingNooks { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }
        public DbSet<BookToRead> BooksToRead { get; set; }
    }
}