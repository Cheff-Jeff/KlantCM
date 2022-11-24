using CM_API_EF.Models;

namespace CM_API_EF.Business_Logic

{
    public class Statistics
    {
        public double AverageRating(List<Rating> ratings)
        {
            List<int> AverageRating = new List<int>();
            int factor;
            double totalRatings;
            int RateSum;
            double ratingPercentage;
            foreach (Rating rating in ratings)
                if (rating.Rate == true)
                {
                    factor = 1;
                    AverageRating.Add(factor);
                }
                else
                {
                    factor = 0;
                    AverageRating.Add(factor);
                }
            totalRatings = AverageRating.Count;
            RateSum = AverageRating.Sum();
            ratingPercentage = RateSum / totalRatings * 100;
            return ratingPercentage;

        }
        public double FindMedian(List<int> indexes)
        {
            double median = 0;
            int[] a = indexes.ToArray();
            Array.Sort(a);
            int arrayLength = a.Length;
            int mid = arrayLength / 2;
            if (arrayLength % 2 == 0)
            {
                double value1 = a[mid];
                double value2 = a[mid - 1];
                median = (value1 + value2) / 2;
            }
            if (arrayLength % 2 == 1)
            {
                median = a[mid];
            }

            return median;


        }



    }



}

