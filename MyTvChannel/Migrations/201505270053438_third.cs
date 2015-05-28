namespace MyTvChannel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyChannels", "DateDeleted", c => c.DateTime());
            AddColumn("dbo.MyShows", "DateDeleted", c => c.DateTime());
            AlterColumn("dbo.MyChannels", "imageUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyChannels", "imageUrl", c => c.String());
            DropColumn("dbo.MyShows", "DateDeleted");
            DropColumn("dbo.MyChannels", "DateDeleted");
        }
    }
}
