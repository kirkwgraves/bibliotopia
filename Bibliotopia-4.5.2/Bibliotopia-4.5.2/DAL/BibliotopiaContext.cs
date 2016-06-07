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
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ReadingNook> ReadingNooks { get; set; }
        public virtual DbSet<FavoriteBook> FavoriteBooks { get; set; }
        public virtual DbSet<ToReadBook> ToReadBooks { get; set; }
    }
}