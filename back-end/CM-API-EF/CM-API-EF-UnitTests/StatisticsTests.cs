using CM_API_EF.Business_Logic;
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
            //creating 2 different ratings one is true and the other false. 
            //therefor the average of positives ratings is expected to be 50%
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
            // Creating a list where the median is expected to by 4,5
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

        [Fact]
        public void ConvertSecondTest()
        {
            //arrange
            //Making a second which when converted should return 7 minutes and 12 seconds
            int seconds = 432;
            //act
            TimeSpan t = statistics.ConvertToMinutes(seconds);
            //assert
            Assert.Equal(t.Minutes, 7);
            Assert.Equal(t.Seconds, 12);
        }
    }
}
