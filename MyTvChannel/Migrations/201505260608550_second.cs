namespace MyTvChannel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyShows", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.MyShows", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.MyShows", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyShows", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MyShows", "Category", c => c.Int(nullable: false));
            DropColumn("dbo.MyShows", "Title");
        }
    }
}
