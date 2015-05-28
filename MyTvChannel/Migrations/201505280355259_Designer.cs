namespace MyTvChannel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Designer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MyShows", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyShows", "Category", c => c.String(nullable: false));
        }
    }
}
