using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Models;

namespace OdeToFood.Tests.Features
{
    [TestClass]
    public class UnitTest1
    {   
        [TestMethod]
        public void Computes_Result_For_One_Review()
        {
            var data = new Restaurant();
            data.Reviews = new List<RestaurantReview>();
            data.Reviews.Add(new RestaurantReview() { Rating = 4 });

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(result.Rating, 4);
        }

        [TestMethod]
        public void Computes_Result_For_Two_Reviews()
        {
            var data = new Restaurant();
            data.Reviews = new List<RestaurantReview>();
            data.Reviews.Add(new RestaurantReview() { Rating = 4 });
            data.Reviews.Add(new RestaurantReview() { Rating = 8 });

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(6, result.Rating);
        }

        
    }
}
