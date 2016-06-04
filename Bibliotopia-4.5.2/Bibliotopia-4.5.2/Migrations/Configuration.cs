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
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Bibliotopia_4._5._2.DAL.BibliotopiaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (!(context.Users.Any(u => u.UserName == "kwg@kwg.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "kwg@kwg.com", PhoneNumber = "6157200896" };
                userManager.Create(userToInsert, "Password@123");
            }

            context.SaveChanges();

            context.ReadingNooks.AddOrUpdate(
                new ReadingNook
                {
                    ReadingNookId = 1,
                    Owner = context.Users.First(u => u.UserName == "kwg@kwg.com"),
                    FavoriteBook = new FavoriteBook { FavoriteBookId = 1, Book = new Book { Title = "Death in Venice", Author = "Thomas Mann", ISBN = 7654321, Synopsis = "Story of modern decadence", Reaction = "Great book", ViewerId = 87654321, BookId = 2 } },
                    BookToRead = new BookToRead { BookToReadId = 1, Book = new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = 1234567, Synopsis = "Story of justice in small town", Reaction = "Loved it", ViewerId = 12345678, BookId = 1 } }
                }
            );
        }
    }
}
