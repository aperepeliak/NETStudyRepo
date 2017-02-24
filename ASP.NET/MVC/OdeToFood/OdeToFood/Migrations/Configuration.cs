namespace OdeToFood.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OdeToFood.Models.OdeToFoodDb";
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Puzata Hata", City = "Poltava", Country = "Ukraine" },
                new Restaurant { Name = "McDonald's", City = "New York", Country = "USA" },
                new Restaurant
                {
                    Name = "Astoria",
                    City = "Moscow",
                    Country = "Russia",
                    Reviews = new List<RestaurantReview>
                    {
                        new RestaurantReview { Rating = 9, Body = "Nice Food.", ReviewerName = "Scott" }
                    }
                });
        }
    }
}
