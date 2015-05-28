namespace MyTvChannel.Migrations
{
    using MyTvChannel.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyTvChannel.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyTvChannel.Models.ApplicationDbContext context)
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

            context.myChannels.AddOrUpdate(x => x.Id,
                new MyChannel() { Id = 1, Name = "CNN", imageUrl = "http://i.cdn.turner.com/dr/teg/turner/release/sites/default/files/images/cnn_c_left_logo.jpg", DateDeleted = null },
                new MyChannel() { Id = 2, Name = "Discovery", imageUrl = "https://bharathisubramanian.files.wordpress.com/2010/01/discovery050409.jpg", DateDeleted = null },
                new MyChannel() { Id = 3, Name = "Sci-Fi", imageUrl = "http://i1.wp.com/SciFi4Me.com/wp-content/uploads/2012/02/featured_syfy_600.jpg?resize=685%2C377", DateDeleted = null },
                new MyChannel() { Id = 4, Name = "ESPN", imageUrl = "http://s.ndtvimg.com/images/stories/espnstar300197.jpg", DateDeleted = null }
                
                );
            context.myShows.AddOrUpdate(x =>x.Id,
                new MyShows() { Id = 1, MyChannelId = 1, Category = ShowCategory.News, Name = "CNN", Title = "NASA WARNING ", Price = 1.80, imageUrl = "https://www.youtube.com/embed/A8PzpxwCASs", DateDeleted = null },
                new MyShows() { Id = 2, MyChannelId = 1, Category = ShowCategory.News, Name = "CNN", Title = "Cell Phone Cancer", Price = 1.80, imageUrl = "https://www.youtube.com/embed/PhKUc4nevxM", DateDeleted = null },

                new MyShows() { Id = 3, MyChannelId = 2, Category = ShowCategory.Documentary, Name = "Discovery", Title = "Early Humans and Water", Price = 1.50, imageUrl = "https://www.youtube.com/embed/v-Fzf8CLg1s", DateDeleted = null },
                new MyShows() { Id = 4, MyChannelId = 2, Category = ShowCategory.Documentary, Name = "Discovery", Title = "Eaten Alive Sneak Peek", Price = 1.50, imageUrl = "https://www.youtube.com/embed/5rrM3zl4J_g", DateDeleted = null },

                new MyShows() { Id = 5, MyChannelId = 3, Category = ShowCategory.Movie, Name = "Sci-Fi", Title = "Avengers", Price = 1.75, imageUrl = "https://www.youtube.com/embed/u1OKBqHICMQ", DateDeleted = null },
                new MyShows() { Id = 6, MyChannelId = 3, Category = ShowCategory.Movie, Name = "Sci-Fi", Title = "Terminator", Price = 1.75, imageUrl = "https://www.youtube.com/embed/jNU_jrPxs-0", DateDeleted = null },

                new MyShows() { Id = 7, MyChannelId = 4, Category = ShowCategory.Sport, Name = "ESPN", Title = "Top 10 Dunks from 2014-2015 NBA ", Price = 2.00, imageUrl = "https://www.youtube.com/embed/aInOK6T6n1w", DateDeleted = null },
                new MyShows() { Id = 8, MyChannelId = 4, Category = ShowCategory.Sport, Name = "ESPN", Title = "One-on-One Tricking Battle", Price = 2.00, imageUrl = "https://www.youtube.com/embed/SAjhv35-q80?list=RDENKh-1qUvJA", DateDeleted = null }
                
                );
        }
    }
}
