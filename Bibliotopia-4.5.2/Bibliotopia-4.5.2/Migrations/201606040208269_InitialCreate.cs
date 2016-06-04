namespace Bibliotopia_4._5._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Synopsis = c.String(),
                        Reaction = c.String(),
                        ViewerId = c.Int(nullable: false),
                        ISBN = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.BookToReads",
                c => new
                    {
                        BookToReadId = c.Int(nullable: false, identity: true),
                        Book_BookId = c.Int(),
                        Id_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookToReadId)
                .ForeignKey("dbo.Books", t => t.Book_BookId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id_Id)
                .Index(t => t.Book_BookId)
                .Index(t => t.Id_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.FavoriteBooks",
                c => new
                    {
                        FavoriteBookId = c.Int(nullable: false, identity: true),
                        Book_BookId = c.Int(),
                        Id_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FavoriteBookId)
                .ForeignKey("dbo.Books", t => t.Book_BookId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id_Id)
                .Index(t => t.Book_BookId)
                .Index(t => t.Id_Id);
            
            CreateTable(
                "dbo.ReadingNooks",
                c => new
                    {
                        ReadingNookId = c.Int(nullable: false, identity: true),
                        BookToRead_BookToReadId = c.Int(),
                        FavoriteBook_FavoriteBookId = c.Int(),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReadingNookId)
                .ForeignKey("dbo.BookToReads", t => t.BookToRead_BookToReadId)
                .ForeignKey("dbo.FavoriteBooks", t => t.FavoriteBook_FavoriteBookId)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.BookToRead_BookToReadId)
                .Index(t => t.FavoriteBook_FavoriteBookId)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ReadingNooks", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReadingNooks", "FavoriteBook_FavoriteBookId", "dbo.FavoriteBooks");
            DropForeignKey("dbo.ReadingNooks", "BookToRead_BookToReadId", "dbo.BookToReads");
            DropForeignKey("dbo.FavoriteBooks", "Id_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavoriteBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.BookToReads", "Id_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookToReads", "Book_BookId", "dbo.Books");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ReadingNooks", new[] { "Owner_Id" });
            DropIndex("dbo.ReadingNooks", new[] { "FavoriteBook_FavoriteBookId" });
            DropIndex("dbo.ReadingNooks", new[] { "BookToRead_BookToReadId" });
            DropIndex("dbo.FavoriteBooks", new[] { "Id_Id" });
            DropIndex("dbo.FavoriteBooks", new[] { "Book_BookId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BookToReads", new[] { "Id_Id" });
            DropIndex("dbo.BookToReads", new[] { "Book_BookId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ReadingNooks");
            DropTable("dbo.FavoriteBooks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.BookToReads");
            DropTable("dbo.Books");
        }
    }
}
