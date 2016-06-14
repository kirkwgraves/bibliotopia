namespace Bibliotopia_4._5._2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bibliotopia_4._5._2.DAL.BibliotopiaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bibliotopia_4._5._2.DAL.BibliotopiaContext context)
        {
            if (!(context.Users.Any(u => u.UserName == "kwg@kwg.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "kwg@kwg.com", PhoneNumber = "6157200896" };
                userManager.Create(userToInsert, "Password@123");
            }

            if (!(context.Users.Any(u => u.UserName == "wbg@wbg.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "wbg@wbg.com", PhoneNumber = "6158229060" };
                userManager.Create(userToInsert, "Password@321");
            }

            context.SaveChanges();

            Book book1 = new Book
            {
                BookId = 5,
                Title = "The Sound and the Fury",
                Author = "William Faulkner",
                Genre = "Literary Fiction",
                GoogleBookId = 12345,

            };

            Book book2 = new Book
            {
                BookId = 7,
                Title = "Heart of Darkness",
                Author = "Joseph Conrad",
                Genre = "Literary Fiction",
                GoogleBookId = 67890
            };

            Book book3 = new Book
            {
                BookId = 13,
                Title = "The Moviegoer",
                Author = "Walker Percy",
                Genre = "Literary Fiction",
                GoogleBookId = 99999
            };

            Book book4 = new Book
            {
                BookId = 98,
                Title = "Watchmen",
                Author = "Alan Moore",
                Genre = "Graphic Novel",
                GoogleBookId = 76767
            };

            Book book5 = new Book
            {
                BookId = 23,
                Title = "Bo Knows Bo",
                Author = "Bo Jackson",
                Genre = "Sports Biography",
                GoogleBookId = 34343
            };

            Book book6 = new Book
            {
                BookId = 88,
                Title = "Zero K",
                Author = "Don DeLillo",
                Genre = "Literary Fiction",
                GoogleBookId = 66666
            };

            Book book7 = new Book
            {
                BookId = 123,
                Title = "Intro to JavaScript",
                Author = "Joe Blogs",
                Genre = "Web Development",
                GoogleBookId = 55555
            };

            Book book8 = new Book
            {
                BookId = 54,
                Title = "Calculus",
                Author = "Professor Jenkins",
                Genre = "Mathematics",
                GoogleBookId = 99999
            };

            FavoriteBook fave_book1 = new FavoriteBook
            {
                FavoriteBookId = 1,
                Book = book1
            };

            FavoriteBook fave_book2 = new FavoriteBook
            {
                FavoriteBookId = 2,
                Book = book2
            };

            FavoriteBook fave_book3 = new FavoriteBook
            {
                FavoriteBookId = 3,
                Book = book3
            };

            FavoriteBook fave_book4 = new FavoriteBook
            {
                FavoriteBookId = 4,
                Book = book7
            };

            ToReadBook to_read1 = new ToReadBook
            {
                ToReadBookId = 1,
                Book = book4
            };

            ToReadBook to_read2 = new ToReadBook
            {
                ToReadBookId = 2,
                Book = book5
            };

            ToReadBook to_read3 = new ToReadBook
            {
                ToReadBookId = 3,
                Book = book6
            };

            ToReadBook to_read4 = new ToReadBook
            {
                ToReadBookId = 4,
                Book = book8
            };

            List<FavoriteBook> fave_books1 = new List<FavoriteBook>
            {
                fave_book1,
                fave_book2
            };

            List<FavoriteBook> fave_books2 = new List<FavoriteBook>
            {
                fave_book3,
                fave_book4
            };

            List<ToReadBook> to_read_books1 = new List<ToReadBook>
            {
                to_read1,
                to_read2
            };

            List<ToReadBook> to_read_books2 = new List<ToReadBook>
            {
                to_read3,
                to_read4
            };


            context.ReadingNooks.AddOrUpdate(
              new ReadingNook
              {
                  Owner = context.Users.First(u => u.UserName == "kwg@kwg.com"),
                  FavoriteBooks = fave_books1,
                  ToReadBooks = to_read_books1
              },

              new ReadingNook
              {
                  Owner = context.Users.First(u => u.UserName == "wbg@wbg.com"),
                  FavoriteBooks = fave_books2,
                  ToReadBooks = to_read_books2
              }
              );
        }
    }
}
