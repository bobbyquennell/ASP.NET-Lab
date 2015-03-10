using Videos.Models;

namespace Videos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VideoDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VideoDb context)
        {
            context.Videos.AddOrUpdate(v=>v.Title,
                new Video(){Length = 120, Title = "MVC4"},
                new Video(){Length = 200, Title = "LINQ"});
            context.SaveChanges();
        }
    }
}
