namespace Bibliotopia_4._5._2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
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

            if (!(context.Users.Any(u => u.UserName == "me@me.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "me@me.com", PhoneNumber = "6158229060" };
                userManager.Create(userToInsert, "Password@321");
            }

            context.SaveChanges();

            context.ReadingNooks.AddOrUpdate(
                //new ReadingNook
                //{
                //    ReadingNookId = 1,
                //    Owner = context.Users.First(u => u.UserName == "kwg@kwg.com"),
                //    FavoriteBook = new FavoriteBook { FavoriteBookId = 1, Book = new Book { Title = "Death in Venice", Author = "Thomas Mann", ISBN = 7654321, Synopsis = "Story of modern decadence", Reaction = "Great book", ViewerId = 87654321, BookId = 2 }, ReadingNookId = 1 },
                //    ToReadBook = new ToReadBook { ToReadBookId = 1, Book = new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = 1234567, Synopsis = "Story of justice in small town", Reaction = "Loved it", ViewerId = 12345678, BookId = 1 }, ReadingNookId = 1 }
                //},

                new ReadingNook
                {
                    ReadingNookId = 2,
                    Owner = context.Users.First(u => u.UserName == "me@me.com"),
                    FavoriteBook = new FavoriteBook { FavoriteBookId = 2, Book = new Book { Title = "Test", Author = "Test Test", ISBN = 3333333, Synopsis = "This is a test", Reaction = "Test", ViewerId = 44444444, BookId = 3 }, ReadingNookId = 2 },
                    ToReadBook = new ToReadBook { ToReadBookId = 2, Book = new Book { Title = "Another Test", Author = "New Test", ISBN = 5555555, Synopsis = "Another test book", Reaction = "Test", ViewerId = 66666666, BookId = 4 }, ReadingNookId = 2 }
                }
            );
        }
    }
}
