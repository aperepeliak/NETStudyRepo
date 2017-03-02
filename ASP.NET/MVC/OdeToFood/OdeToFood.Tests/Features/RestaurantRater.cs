using System;
using OdeToFood.Models;
using System.Linq;

namespace OdeToFood.Tests.Features
{
    internal class RestaurantRater
    {
        private Restaurant _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            _restaurant = restaurant;
        }

        public RatingResult ComputeRating(int numberOfReviews)
        {
            var result = new RatingResult();
            result.Rating = (int)_restaurant.Reviews.Average(r => r.Rating);

            return result;
        }
    }
}