namespace Bibliotopia_4._5._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "CoverImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "CoverImageUrl");
        }
    }
}
