﻿using CM_API_EF.Business_Logic;
using CM_API_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_API_EF_UnitTests
{
    public class StatisticsTests
    {
        Statistics statistics = new Statistics();

        [Fact]
        public void AverageTest()
        {
            //arrange
            List<Rating> ratings = new List<Rating>();
            Rating rating = new Rating();
            rating.Rate = true;
            ratings.Add(rating);
            Rating rating1 = new Rating();
            rating1.Rate = false;
            ratings.Add(rating1);
            //act
            double percentage = statistics.AverageRating(ratings);
            //assert
            Assert.Equal(50, percentage);
        }

        [Fact]
        public void MedianTest()
        {
            //arrange
            List<int> indexes = new List<int>();
            indexes.Add(9);
            indexes.Add(1);           
            indexes.Add(8);
            indexes.Add(3);
            indexes.Add(4);
            indexes.Add(5);
            indexes.Add(2);
            indexes.Add(6);

            //act
            double median = statistics.FindMedian(indexes);

            //assert
            Assert.Equal(4.5, median);
            


        }
    }
}
